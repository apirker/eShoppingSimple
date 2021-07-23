using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Interface which the response events to a request need to implement.
    /// </summary>
    public interface IEventResponse : IEvent
    {
        /// <summary>
        /// Event id of the request id.
        /// </summary>
        public Guid RequestEventId { get; }
    }
}
