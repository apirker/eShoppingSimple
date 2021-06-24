namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEventHandler
    {
        void Handle(object @event);
    }
}
