using eShoppingSimple.Orders.Domain.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Orders.Domain.Implementations
{
    class Item : IItem
    {
        private readonly IList<Picture> pictures;

        public Item(Guid id, string name, float price, IList<byte[]> pictures)
        {
            Id = id;
            Name = name;
            Price = price;

            this.pictures = pictures.Select(picture => new Picture(picture)).ToList();
        }

        public Guid Id { get; }

        public float Price { get; }

        public string Name { get; }

        public IEnumerable<IPicture> Pictures => pictures.Select(p => p as IPicture);
    }
}
