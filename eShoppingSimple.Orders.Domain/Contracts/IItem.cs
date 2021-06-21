using System;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    public interface IItem
    {
        Guid Id { get; }
        string Name { get; }
        float Price { get; }
    }
}
