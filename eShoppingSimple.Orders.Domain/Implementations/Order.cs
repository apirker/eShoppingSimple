using eShoppingSimple.Orders.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Orders.Domain.Implementations
{
    class Order : IOrder
    {
        private IList<Item> items = new List<Item>();

        public Order(Guid orderId, Guid customerId, IEnumerable<(Guid itemId, string name, float price, IList<string> pictures)> items)
        {
            Id = orderId;
            CustomerId = customerId;

            this.items = items.Select(i => new Item(i.itemId, i.name, i.price, i.pictures)).ToList();
        }

        public Guid Id { get; set; }

        public Guid CustomerId { get; }

        public IEnumerable<IItem> Items => items.Select(i => i as IItem);

        internal void AddItem(Guid itemId, string name, float price, IList<string> pictures)
        {
            if (items.Any(i => i.Id == itemId))
                throw new InvalidOperationException();

            items.Add(new Item(itemId, name, price, pictures));
        } 

        internal void RemoveItem(Guid itemId)
        {
            if (!items.Any(i => i.Id == itemId))
                throw new InvalidOperationException();
            
            var item = items.First(i => i.Id == itemId);
            items.Remove(item);
        }

        internal void ChangeItems(IEnumerable<(Guid itemId, string name, float price, IList<string> pictures)> items)
        {
            this.items = items.Select(i => new Item(i.itemId, i.name, i.price, i.pictures)).ToList();
        }
    }
}
