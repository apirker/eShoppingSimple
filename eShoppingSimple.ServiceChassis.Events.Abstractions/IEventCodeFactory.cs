using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Interface which defines how event codes translate to event types.
    /// </summary>
    public interface IEventCodeFactory
    {
        /// <summary>
        /// Return the event code.
        /// </summary>
        string GetEventCode(Type type);

        /// <summary>
        /// Return the event type.
        /// </summary>
        Type GetEventType(string code);
    }
}
