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
    /// <summary>
    /// Static initi
    /// </summary>
    public static class ShippingStorageInitializer
    {
        /// <summary>
        /// Registers the mapper between domain and data model.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddStorageMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMapper<IPacket, Packet>, PacketMapper>();
        }

        /// <summary>
        /// Create a new storage startup, with the PacketContext as dbcontext, the PacketModelBuilderConfiguration for setting up the 
        /// datamodel, and mapping IPacket from the domain to Packet in the data model.
        /// </summary>
        /// <returns></returns>
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
