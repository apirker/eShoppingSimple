using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEvent
    {
        Guid EventId { get; }
    }
}
