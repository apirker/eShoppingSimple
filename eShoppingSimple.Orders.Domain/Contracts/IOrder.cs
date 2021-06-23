using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    public interface IOrder : IHasId
    {
        Guid CustomerId { get; }
        IEnumerable<IItem> Items { get; }
    }
}
