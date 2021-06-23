using eShoppingSimple.Orders.Domain.Contracts;
using eShoppingSimple.Orders.Storage.EfCore;
using eShoppingSimple.Orders.Storage.Mapper;
using eShoppingSimple.Orders.Storage.Model;
using eShoppingSimple.ServiceChassis.Storage;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Storage
{
    public static class OrderStorageInitializer
    {
        public static void AddStorageMapper(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IMapper<IOrder, Order>, OrderMapper>();
        }

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
