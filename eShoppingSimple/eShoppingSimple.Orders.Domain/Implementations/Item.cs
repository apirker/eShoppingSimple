using eShoppingSimple.Orders.Domain.Contracts;
using System;

namespace eShoppingSimple.Orders.Domain.Implementations
{
    class Item : IItem
    {
        public Item(Guid id, string name, float price)
        {
            Id = id;
            Name = name;
            Price = price;
        }

        public Guid Id { get; }

        public float Price { get; }

        public string Name { get; }
    }
}
