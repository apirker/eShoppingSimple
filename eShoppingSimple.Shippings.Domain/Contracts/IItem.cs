using System;

namespace eShoppingSimple.Shippings.Domain.Contracts
{
    public interface IItem
    {
        Guid Id { get; }

        float Weight { get; }

        IOrder Order { get; }
    }
}
