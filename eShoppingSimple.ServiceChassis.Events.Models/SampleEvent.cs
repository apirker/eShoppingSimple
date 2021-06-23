using eShoppingSimple.ServiceChassis.Events.Abstractions;
using System;

namespace eShoppingSimple.ServiceChassis.Events.Models
{
    public class SampleEvent : IEvent
    {
        public SampleEvent(string message)
        {
            EventId = Guid.NewGuid();
            Message = message;
        }

        public string Message { get; set; }
        public Guid EventId { get; set; }
    }
}
