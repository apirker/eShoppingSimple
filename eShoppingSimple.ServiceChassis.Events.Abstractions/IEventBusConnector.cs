using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Connector interface which concrete event bus provider need to implement.
    /// </summary>
    public interface IEventBusConnector : IDisposable
    {
        /// <summary>
        /// Create a queue on the provider.
        /// </summary>
        void CreateQueue(string queueName, bool durable, bool exclusive, bool autoDelete);

        /// <summary>
        /// Publish an event on the event provider.
        /// </summary>
        ulong PublishEvent(string eventCode, string serializedArgs);

        /// <summary>
        /// Subscribe to event happening on the event bus with a code and a queuename.
        /// </summary>
        void SubscribeToEvent(string eventCode, string queueName);

        /// <summary>
        /// Unsubscribe from events on the event bus.
        /// </summary>
        void UnsubscribeFromEvent(string eventCode, string queueName);

        /// <summary>
        /// Start the event bus connector.
        /// </summary>
        void Start();

        /// <summary>
        /// Stop the event bus connector.
        /// </summary>
        void Stop();

        /// <summary>
        /// Retry an event on the event bus.
        /// </summary>
        void RetryEvent(ulong messageIdentifier);

        /// <summary>
        /// Commit an event on the event bus.
        /// </summary>
        /// <param name="messageIdentifier"></param>
        void CommitEvent(ulong messageIdentifier);

        /// <summary>
        /// Event which is raised when a new event is received.
        /// </summary>
        event EventHandler<MessageArgs> MessageReceived;

    }
}
