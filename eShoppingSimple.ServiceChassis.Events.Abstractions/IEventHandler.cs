namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEventHandler<T> where T:IEvent
    {
        void Handle(T @event);
    }
}
