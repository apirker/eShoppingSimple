using System;

namespace eShoppingSimple.Orders.Storage.Model
{
    public class Picture
    {
        public Guid Id { get; set; }
        public byte[] Content { get; set; }
    }
}
