using eShoppingSimple.Orders.Domain.Contracts;
using eShoppingSimple.Orders.Storage.Model;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Orders.Storage.Mapper
{
    class OrderMapper : IMapper<IOrder, Order>
    {
        public Order Map(IOrder domain)
        {
            return new Order()
            {
                Id = domain.Id,
                CustomerId = domain.CustomerId,
                Items = domain.Items.Select(i => new Item
                {
                    Id = i.Id,
                    Name = i.Name,
                    Price = i.Price,
                    Pictures = i.Pictures.Select(p => new Picture
                    {
                        Content = p.Content
                    }).ToList()
                }).ToList()
            };
        }

        public IOrder Map(Order storage)
        {
            var items = new List<(Guid itemId, string name, float price, IList<string> pictures)>();

            foreach (var item in storage.Items)
                items.Add((item.Id, item.Name, item.Price, item.Pictures.Select(p => p.Content).ToList()));

            return OrderFactory.Create(storage.Id, storage.CustomerId, items);
        }

        public void Map(IOrder source, Order destination)
        {
            destination.Id = destination.Id;
            destination.CustomerId = source.CustomerId;
            destination.Items = source.Items.Select(i => new Item
            {
                Id = i.Id,
                Name = i.Name,
                Price = i.Price,
                Pictures = i.Pictures.Select(p => new Picture
                {
                    Content = p.Content
                }).ToList()
            }).ToList();
        }
    }
}
