using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.EfCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Storage
{
    public class StorageStartup<TDbContext, TModelBuilderConfiguration> : IStorageStartup
        where TDbContext : DbContext
        where TModelBuilderConfiguration : class, IModelBuilderConfiguration
    {
        private readonly IList<(Type DomainType, Type StorageType)> mappings;

        public StorageStartup(IList<(Type DomainType, Type StorageType)> mappings)
        {
            this.mappings = mappings;
        }
        public void Configure(IServiceCollection services, StorageSettings storageSettings)
        {
            services.AddEfCore(storageSettings);

            foreach (var (domainType, storageType) in mappings)
            {
                Type repoInterfaceType = typeof(IRepository<>);
                Type repoConcreteType = typeof(Repository<,>);

                Type storageInterfaceType = typeof(IDataStorage<>);
                Type storageConcreteType = typeof(DataStorageEf<>);

                Type constructedRepoInterfaceType = repoInterfaceType.MakeGenericType(domainType);
                Type constructedRepoConcreteType = repoConcreteType.MakeGenericType(domainType, storageType);

                Type constructedStorageInterfaceType = storageInterfaceType.MakeGenericType(storageType);
                Type constructedStorageConcreteType = storageConcreteType.MakeGenericType(storageType);

                services.AddTransient(constructedRepoInterfaceType, constructedRepoConcreteType);
                services.AddTransient(constructedStorageInterfaceType, constructedStorageConcreteType);
            }

            services.AddScoped<DbContext, TDbContext>();
            services.AddTransient<IModelBuilderConfiguration, TModelBuilderConfiguration>();
        }
    }
}
