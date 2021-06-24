using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEventBusConnector : IDisposable
    {
        void CreateQueue(string queueName, bool durable, bool exclusive, bool autoDelete);
        ulong Publish(string eventCode, string serializedArgs);
        void Subscribe(string eventCode, string queueName);
        void Unsubscribe(string eventCode, string queueName);
        void Start();
        void Stop();
        void RetryMessage(ulong messageIdentifier);
        void CommitMessage(ulong messageIdentifier);

        event EventHandler<MessageArgs> MessageReceived;

    }
}
