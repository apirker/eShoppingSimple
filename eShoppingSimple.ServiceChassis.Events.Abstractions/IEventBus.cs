namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Interface how an event bus looks like for the domain assemblies.
    /// </summary>
    public interface IEventBus
    {
        /// <summary>
        /// Subscribe to events with a handler.
        /// </summary>
        void Subscribe<T>(IEventHandler eventHandler) where T : IEvent;

        /// <summary>
        /// Unsubscribe from an event.
        /// </summary>
        void Unsubscribe<T>(IEventHandler eventHandler) where T : IEvent;

        /// <summary>
        /// Publish an event on the event bus.
        /// </summary>
        void Publish<T>(T @event) where T : IEvent;

        /// <summary>
        /// Sync way to perform request-response actions via messaging.
        /// </summary>
        U PublishRequestAndWait<T, U>(T requestEvent)
            where T : IEvent
            where U : IEventResponse;

        /// <summary>
        /// Starts the event bus.
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the event bus.
        /// </summary>
        void Stop();
    }
}
