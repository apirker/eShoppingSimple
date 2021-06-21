using eShoppingSimple.Orders.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Orders.Domain.Implementations
{
    class Order : IOrder
    {
        private readonly IList<Item> items = new List<Item>();

        public Order(Guid orderId, Guid customerId, IEnumerable<(Guid itemId, string name, float price)> items)
        {
            OrderId = orderId;
            CustomerId = customerId;

            this.items = items.Select(i => new Item(i.itemId, i.name, i.price)).ToList();
        }

        public Guid OrderId { get; }

        public Guid CustomerId { get; }

        public IEnumerable<IItem> Items => items.Select(i => i as IItem);
    }
}
