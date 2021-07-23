using eShoppingSimple.ServiceChassis.Storage.EfCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShoppingSimple.ServiceChassis.Storage
{
    /// <summary>
    /// Interface which storage startups need to implement.
    /// </summary>
    public interface IStorageStartup
    {
        /// <summary>
        /// Method to configure the dependency injection framework with the storage settings.
        /// </summary>
        void Configure(IServiceCollection services, StorageSettings storageSettings);

        /// <summary>
        /// Method to make sure the DB is there.
        /// </summary>
        void EnsureCreated(IServiceProvider serviceProvider);
    }
}
