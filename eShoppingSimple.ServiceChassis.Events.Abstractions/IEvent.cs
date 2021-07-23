using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Interface which all events must implement.
    /// </summary>
    public interface IEvent
    {
        /// <summary>
        /// Every event has an id.
        /// </summary>
        Guid EventId { get; }
    }
}
