using eShoppingSimple.ServiceChassis.Events.Abstractions;
using System;

namespace eShoppingSimple.ServiceChassis.Events.Models
{
    public class EventCodeFactory : IEventCodeFactory
    {
        private const string SampleEventCode = "SampleEvent";

        public string GetEventCode(Type type)
        {
            if (type == typeof(SampleEvent))
                return SampleEventCode;

            throw new NotSupportedException();
        }

        public Type GetEventType(string code)
        {
            if (code == SampleEventCode)
                return typeof(SampleEvent);

            throw new NotSupportedException();
        }
    }
}
