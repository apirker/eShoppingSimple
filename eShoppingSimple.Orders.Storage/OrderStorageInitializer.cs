using eShoppingSimple.Orders.Domain.Contracts;
using eShoppingSimple.Orders.Storage.EfCore;
using eShoppingSimple.Orders.Storage.Mapper;
using eShoppingSimple.Orders.Storage.Model;
using eShoppingSimple.ServiceChassis.Storage;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Storage
{
    /// <summary>
    /// Storage initializer class.
    /// </summary>
    public static class OrderStorageInitializer
    {
        /// <summary>
        /// Registers the mapper between domain and data model.
        /// </summary>
        /// <param name="serviceCollection"></param>
        public static void AddStorageMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMapper<IOrder, Order>, OrderMapper>();
        }

        /// <summary>
        /// Create a new storage startup, with the OrderContext as dbcontext, the OrderModelBuilderConfiguration for setting up the 
        /// datamodel, and mapping IOrder from the domain to Order in the data model.
        /// </summary>
        /// <returns></returns>
        public static IStorageStartup CreateStorageStartup()
        {
            return new StorageStartup<OrderContext, OrderModelBuilderConfiguration>(
                new List<(Type DomainType, Type StorageType)>
                {
                    (typeof(IOrder),typeof(Order))
                });
        }
    }
}
