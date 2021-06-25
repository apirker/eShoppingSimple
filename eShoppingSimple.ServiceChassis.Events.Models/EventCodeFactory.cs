using eShoppingSimple.ServiceChassis.Events.Abstractions;
using System;

namespace eShoppingSimple.ServiceChassis.Events.Models
{
    public class EventCodeFactory : IEventCodeFactory
    {
        private const string SampleEventCode = "SampleEvent";
        private const string SampleRequestEventCode = "SampleRequestEvent";
        private const string SampleResponseEventCode = "SampleResponseEvent";

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
