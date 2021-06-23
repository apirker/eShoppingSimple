using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Storage.Model
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public IList<Picture> Pictures { get; set; }
    }
}
