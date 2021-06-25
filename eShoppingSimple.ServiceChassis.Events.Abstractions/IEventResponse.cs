using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEventResponse : IEvent
    {
        public Guid RequestEventId { get; }
    }
}
