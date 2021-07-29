using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Storage.Model
{
    class Packet : IHasId
    {
        public Guid Id { get; set; }

        public string Destination { get; set; }

        public string DeliveryService { get; set; }

        public IList<Item> Items { get; set; }
    }
}
