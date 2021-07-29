using System;

namespace eShoppingSimple.Shippings.Storage.Model
{
    class Item
    {
        public Guid Id { get; set; }

        public float Weight { get; set; }

        public Order Order { get; set; }
    }
}
