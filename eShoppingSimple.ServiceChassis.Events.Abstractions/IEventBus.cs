namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEventBus
    {
        void Subscribe<T>(IEventHandler eventHandler) where T : IEvent;
        void Unsubscribe<T>(IEventHandler eventHandler) where T : IEvent;

        void Publish<T>(T @event) where T : IEvent;
        U PublishRequestAndWait<T, U>(T requestEvent)
            where T : IEvent
            where U : IEventResponse;

        void Start();
        void Stop();
    }
}
