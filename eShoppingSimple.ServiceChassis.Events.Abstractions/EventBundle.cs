using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Aggregates together multiple events in one package.
    /// </summary>
    public class EventBundle
    {
        private readonly IList<IEvent> events = new List<IEvent>();

        /// <summary>
        /// Add an event to the bundle.
        /// </summary>
        public void AddEvent(IEvent @event)
        {
            events.Add(@event);
        }

        /// <summary>
        /// Publish all events of the bundle on the event bus.
        /// </summary>
        public void Publish(IEventBus eventBus)
        {
            foreach (var @event in events)
                eventBus.Publish(@event);
        }
    }
}
