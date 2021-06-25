using eShoppingSimple.ServiceChassis.Events.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.Events.Models
{
    public class SampleRequestEvent : IEvent
    {
        public SampleRequestEvent(string message, Guid eventId)
        {
            EventId = eventId;
            Message = message;
        }

        public string Message { get; set; }
        public Guid EventId { get; set; }
    }
}
