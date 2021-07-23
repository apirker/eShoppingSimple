namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Interface which an event handler needs to implement.
    /// </summary>
    public interface IEventHandler
    {
        /// <summary>
        /// Method which gets invoked when a new event arrives.
        /// </summary>
        void Handle(object @event);
    }
}
