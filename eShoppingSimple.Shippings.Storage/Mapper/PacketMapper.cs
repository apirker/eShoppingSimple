using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using eShoppingSimple.Shippings.Domain.Contracts;
using eShoppingSimple.Shippings.Storage.Model;
using System;
using System.Linq;

namespace eShoppingSimple.Shippings.Storage.Mapper
{
    /// <summary>
    /// Mapper to map between domain and data model for packets
    /// </summary>
    class PacketMapper : IMapper<IPacket, Packet>
    {
        public Packet Map(IPacket domain)
        {
            return new Packet
            {
                Id = domain.Id,
                DeliveryService = domain.DeliveryService,
                Destination = domain.Destination,
                Items = domain.Items.Select(i => 
                new Item
                {
                    Id = i.Id,
                    Weight = i.Weight,
                    Order = new Order { Id = i.Id}
                }).ToList()
            };
        }

        public IPacket Map(Packet storage)
        {
            return PacketFactory.Create(storage.Id, storage.Destination, storage.DeliveryService, storage.Items.Select(i => (i.Id, i.Weight, i.Order.Id)).ToList());
        }

        public void Map(IPacket source, Packet destination)
        {
            destination.Id = source.Id;
            destination.DeliveryService = source.DeliveryService;
            destination.Destination = source.Destination;
            destination.Items = source.Items.Select(i =>
            new Item
            {
                Id = i.Id,
                Weight = i.Weight,
                Order = new Order { Id = i.Id }
            }).ToList();
        }
    }
}
