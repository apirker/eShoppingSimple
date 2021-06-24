using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    internal class EventBusManager : IEventBus
    {
        private readonly IDictionary<Type, HashSet<IEventHandler>> handlersByEventType = new Dictionary<Type, HashSet<IEventHandler>>();

        private readonly IEventBusConnector connector;
        private readonly IEventCodeFactory eventCodeFactory;
        private readonly EventBusManagerSettings options;
        private readonly object lockObject = new object();
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

        public EventBusManager( IEventBusConnector connector, IEventCodeFactory eventCodeFactory, EventBusManagerSettings options)
        {
            this.connector = connector;
            this.eventCodeFactory = eventCodeFactory;
            this.options = options;
            this.connector.CreateQueue(options.ServiceName, true, false, false);
            
            this.connector.MessageReceived += OnHandleMessage;
        }

        public void Publish<T>(T @event) where T:IEvent
        {
            var eventCode = eventCodeFactory.GetEventCode(@event.GetType());
            var serializedEvent = JsonConvert.SerializeObject(@event);

            connector.Publish(eventCode, serializedEvent);
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
                    connector.Subscribe(eventCode, options.ServiceName);

                }
            }
        }

        public void Unsubscribe<T>(IEventHandler eventHandler) where T : IEvent
        {
            if (eventHandler == null) throw new ArgumentException("Event handler cant be null.");
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
                            connector.Unsubscribe(eventCode, options.ServiceName);
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
