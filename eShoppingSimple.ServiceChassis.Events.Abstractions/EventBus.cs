using Newtonsoft.Json;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public class EventBus : IEventBus
    {
        private readonly IDictionary<Type, HashSet<IEventHandler>> handlersByEventType = new Dictionary<Type, HashSet<IEventHandler>>();
        private readonly IDictionary<Guid, ResponseEventAndMutex> mutexDictionary = new ConcurrentDictionary<Guid, ResponseEventAndMutex>();

        private readonly IEventBusConnector connector;
        private readonly IEventCodeFactory eventCodeFactory;
        private readonly EventSettings options;
        private readonly object lockObject = new object();
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private Guid instanceId;
        private string requestResponseQueueName;

        public EventBus(IEventBusConnector connector, IEventCodeFactory eventCodeFactory, EventSettings options)
        {
            this.connector = connector;
            this.eventCodeFactory = eventCodeFactory;
            this.options = options;

            this.instanceId = Guid.NewGuid();
            this.requestResponseQueueName = options.ServiceName + $"-{instanceId}";

            this.connector.CreateQueue(options.ServiceName, true, false, false);
            this.connector.CreateQueue(requestResponseQueueName, true, true, true);

            this.connector.MessageReceived += OnHandleMessage;
        }

        public void Publish<T>(T @event) where T:IEvent
        {
            var eventCode = eventCodeFactory.GetEventCode(@event.GetType());
            var serializedEvent = JsonConvert.SerializeObject(@event);

            connector.Publish(eventCode, serializedEvent);
        }

        public U PublishRequestAndWait<T, U>(T requestEvent)
            where T : IEvent
            where U : IEventResponse
        {
            var waithandle = new AutoResetEvent(false);
            var callback = new ResponseEventAndMutex(waithandle);
            mutexDictionary.Add(requestEvent.EventId, callback);

            var responseEventHandler = new ResponseEventHandler<U>(this);
            Subscribe<U>(responseEventHandler);
            Start();

            Publish(requestEvent);

            waithandle.WaitOne(options.MaxResponseWaitingTime);

            Unsubscribe<U>(responseEventHandler);
            mutexDictionary.Remove(requestEvent.EventId);
            if (callback.Response == null)
                throw new InvalidOperationException();

            return (U)callback.Response;
        }

        public void SignalWaitingRequestEvent(IEventResponse responseEvent)
        {
            if (mutexDictionary.ContainsKey(responseEvent.RequestEventId))
            {
                mutexDictionary[responseEvent.RequestEventId].Response = responseEvent;
                mutexDictionary[responseEvent.RequestEventId].WaitHandle.Set();
            }
        }

        public void Subscribe<T>(IEventHandler eventHandler) where T : IEvent
        {
            lock (lockObject)
            {
                Type eventType = typeof(T);
                string eventCode = eventCodeFactory.GetEventCode(eventType);

                if (!handlersByEventType.ContainsKey(eventType))
                {
                    handlersByEventType.Add(eventType, new HashSet<IEventHandler> { eventHandler });
                    if (typeof(T).IsAssignableTo(typeof(IEventResponse)))
                    {
                        if (!string.IsNullOrEmpty(requestResponseQueueName))
                            connector.Subscribe(eventCode, requestResponseQueueName);
                    }
                    else
                    {
                        connector.Subscribe(eventCode, options.ServiceName);
                    }
                }
            }
        }

        public void Unsubscribe<T>(IEventHandler eventHandler) where T : IEvent
        {
            lock (lockObject)
            {
                Type eventType = typeof(T);
                string eventCode = eventCodeFactory.GetEventCode(eventType);

                if (handlersByEventType.ContainsKey(eventType))
                {
                    if (handlersByEventType[eventType].Remove(eventHandler))
                    {
                        if (handlersByEventType[eventType].Count == 0)
                        {
                            handlersByEventType.Remove(eventType);
                            if (typeof(T).IsAssignableTo(typeof(IEventResponse)))
                            {
                                if (!string.IsNullOrEmpty(requestResponseQueueName))
                                    connector.Unsubscribe(eventCode, requestResponseQueueName);
                            }
                            else
                            {
                                connector.Unsubscribe(eventCode, options.ServiceName);
                            }
                        }
                    }
                }
            }
        }

        public void Start()
        {
            connector.Start();
        }

        public void Stop()
        {
            connector.Stop();
        }

        private void OnHandleMessage(object sender, MessageArgs messageArgs)
        {
            try
            {
                var eventCode = messageArgs.Event;
                var eventType = eventCodeFactory.GetEventType(eventCode);

                Dictionary<Type, HashSet<IEventHandler>> materializedHandlersByEventType;

                lock (lockObject)
                {
                    materializedHandlersByEventType = handlersByEventType.ToDictionary(x => x.Key, x => x.Value);
                }

                var eventTypeHandlerPair =
                    materializedHandlersByEventType.Single(x => x.Key.FullName == eventType.FullName);

                var eventHandlers = eventTypeHandlerPair.Value.ToList();

                var @event = JsonConvert.DeserializeObject(messageArgs.JsonArgs, eventType);
                List<Exception> exceptions = new List<Exception>();
                
                foreach (var handler in eventHandlers)
                {
                    try
                    {
                        handler.Handle(@event);
                    }
                    catch (Exception e)
                    {
                        exceptions.Add(e);
                    }
                }

                //If any exceptions throw it here to be handled in catch
                if (exceptions.Count > 0) throw new AggregateException(exceptions);

                //Successfully commit message
                connector.CommitMessage(messageArgs.MessageIdentifier);
            }
            catch (Exception)
            {
                connector.RetryMessage(messageArgs.MessageIdentifier);
            }
        }

        private class ResponseEventAndMutex
        {
            public ResponseEventAndMutex(AutoResetEvent waitHandle)
            {
                this.WaitHandle = waitHandle;
            }

            public AutoResetEvent WaitHandle { get; }
            public IEventResponse Response { get; set; }
        }

        private class ResponseEventHandler<T> : IEventHandler where T : IEventResponse
        {
            private readonly EventBus eventBus;
            
            public ResponseEventHandler(EventBus eventBus)
            {
                this.eventBus = eventBus;
            }

            public void Handle(object @event)
            {
                Task.Run(() => { eventBus.SignalWaitingRequestEvent((T)@event); });
            }
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (connector != null)
                {
                    connector.MessageReceived -= OnHandleMessage;
                }

                cancellationTokenSource?.Cancel();
                cancellationTokenSource?.Dispose();

                connector?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
