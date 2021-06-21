using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    public interface IOrder
    {
        Guid OrderId { get; }
        Guid CustomerId { get; }

        IEnumerable<IItem> Items { get; }
    }
}
