using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEvent
    {
        Guid EventId { get; }
    }
}
