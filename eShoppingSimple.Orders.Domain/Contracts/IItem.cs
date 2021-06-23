using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    public interface IItem
    {
        Guid Id { get; }
        string Name { get; }
        float Price { get; }
        IEnumerable<IPicture> Pictures { get; }
    }
}
