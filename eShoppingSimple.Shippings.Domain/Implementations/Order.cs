using eShoppingSimple.Shippings.Domain.Contracts;
using System;

namespace eShoppingSimple.Shippings.Domain.Implementations
{
    class Order : IOrder
    {
        public Guid Id { get; private set; }

        public Order(Guid id)
        {
            Id = id;
        }
    }
}
