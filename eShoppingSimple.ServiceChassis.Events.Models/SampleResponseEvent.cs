using eShoppingSimple.ServiceChassis.Events.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.Events.Models
{
    public class SampleResponseEvent : IEventResponse
    {
        public SampleResponseEvent(Guid eventId, Guid requestEventId, string response)
        {
            EventId = eventId;
            RequestEventId = requestEventId;
            Response = response;
        }

        public Guid RequestEventId { get; set; }

        public Guid EventId { get; set; }

        public string Response { get; set; }
    }
}
