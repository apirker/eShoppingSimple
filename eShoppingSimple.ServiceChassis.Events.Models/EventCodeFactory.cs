using eShoppingSimple.ServiceChassis.Events.Abstractions;
using System;

namespace eShoppingSimple.ServiceChassis.Events.Models
{
    /// <summary>
    /// Example factory how to map between event code and event type.
    /// </summary>
    public class EventCodeFactory : IEventCodeFactory
    {
        private const string SampleEventCode = "SampleEvent";
        private const string SampleRequestEventCode = "SampleRequestEvent";
        private const string SampleResponseEventCode = "SampleResponseEvent";

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public string GetEventCode(Type type)
        {
            if (type == typeof(SampleEvent))
                return SampleEventCode;

            if (type == typeof(SampleRequestEvent))
                return SampleRequestEventCode;

            if (type == typeof(SampleResponseEvent))
                return SampleResponseEventCode;

            throw new NotSupportedException();
        }

        /// <summary>
        /// <inheritdoc />
        /// </summary>
        public Type GetEventType(string code)
        {
            if (code == SampleEventCode)
                return typeof(SampleEvent);

            if (code == SampleRequestEventCode)
                return typeof(SampleRequestEvent);

            if (code == SampleResponseEventCode)
                return typeof(SampleResponseEvent);

            throw new NotSupportedException();
        }
    }
}
