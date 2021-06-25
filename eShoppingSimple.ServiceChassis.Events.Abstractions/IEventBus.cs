namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEventBus
    {
        void Subscribe<T>(IEventHandler eventHandler) where T : IEvent;
        void Unsubscribe<T>(IEventHandler eventHandler) where T : IEvent;
        void Publish<T>(T @event) where T : IEvent;

        void Start();
        void Stop();
    }
}
