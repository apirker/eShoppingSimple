using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    public static class EfInitializer
    {
        public static void AddEfCore(this IServiceCollection serviceCollection, StorageSettings storageSettings)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWorkEf>();
            serviceCollection.AddSingleton(storageSettings);
        }
    }
}
