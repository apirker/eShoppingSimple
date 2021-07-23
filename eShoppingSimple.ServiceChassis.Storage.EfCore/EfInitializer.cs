using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    /// <summary>
    /// Static initializer class for entity framework
    /// </summary>
    public static class EfInitializer
    {
        /// <summary>
        /// Adds the support for entity framework to the dependency injection.
        /// </summary>
        public static void AddEfCore(this IServiceCollection serviceCollection, StorageSettings storageSettings)
        {
            serviceCollection.AddTransient<IUnitOfWork, UnitOfWorkEf>();
            serviceCollection.AddSingleton(storageSettings);
        }
    }
}
