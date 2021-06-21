using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public class EventBundle
    {
        private readonly IList<IEvent> events = new List<IEvent>();

        public void AddEvent(IEvent @event)
        {
            events.Add(@event);
        }

        public void Publish(IEventBus eventBus)
        {
            foreach (var @event in events)
                eventBus.Publish(@event);
        }
    }
}
