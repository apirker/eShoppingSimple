using eShoppingSimple.Shippings.Domain.Contracts;
using System;

namespace eShoppingSimple.Shippings.Domain.Implementations
{
    class Item : IItem
    {
        public Guid Id { get; private set; }

        public float Weight { get; private set; }

        public IOrder Order { get; private set; }

        public Item(Guid id, float weight, Guid orderId)
        {
            Id = id;
            Weight = weight;
            Order = new Order(orderId);
        }
    }
}
