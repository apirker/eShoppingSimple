using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Storage.Model
{
    public class Order : IHasId
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public IList<Item> Items { get; set; }
    }
}
