using eShoppingSimple.ServiceChassis.Storage;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using eShoppingSimple.Shippings.Domain.Contracts;
using eShoppingSimple.Shippings.Storage.EfCore;
using eShoppingSimple.Shippings.Storage.Mapper;
using eShoppingSimple.Shippings.Storage.Model;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Storage
{
    public static class ShippingStorageInitializer
    {
        public static void AddStorageMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMapper<IPacket, Packet>, PacketMapper>();
        }

        public static IStorageStartup CreateStorageStartup()
        {
            return new StorageStartup<PacketContext, PacketModelBuilderConfiguration>(
                new List<(Type DomainType, Type StorageType)>
                {
                    (typeof(IPacket),typeof(Packet))
                });
        }
    }
}
