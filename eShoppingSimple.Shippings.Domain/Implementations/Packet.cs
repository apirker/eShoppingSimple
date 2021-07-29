using eShoppingSimple.Shippings.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Shippings.Domain.Implementations
{
    class Packet : IPacket
    {
        private IList<Item> items;

        public Guid Id { get; set; }

        public string Destination { get; }

        public string DeliveryService { get; }

        public float TotalWeight => items.Sum(i => i.Weight);

        public IList<IItem> Items => items.Select(i => i as IItem).ToList();

        private const string deliveryServiceFast = "Fast";
        private const float deliveryServiceFastMax = 300;

        private const string deliveryServiceSlow = "Slow";
        private const float deliveryServiceSlowMax = 500;

        public Packet(Guid id, string destination, string deliveryService, IList<(Guid id, float weight, Guid orderId)> items)
        {
            Id = id;
            Destination = destination;
            DeliveryService = deliveryService;

            this.items = new List<Item>();

            foreach (var item in items)
                AddItem(item.id, item.weight, item.orderId);
        }

        internal void AddItem(Guid id, float weight, Guid orderId)
        {
            if (DeliveryService == deliveryServiceFast)
                if (TotalWeight + weight > deliveryServiceFastMax)
                    throw new InvalidOperationException();

            if(DeliveryService == deliveryServiceSlow)
                if (TotalWeight + weight > deliveryServiceSlowMax)
                    throw new InvalidOperationException();

            items.Add(new Item(id, weight, orderId));
        }
    }
}
