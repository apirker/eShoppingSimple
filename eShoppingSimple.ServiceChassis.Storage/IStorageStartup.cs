using eShoppingSimple.ServiceChassis.Storage.EfCore;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Storage
{
    public interface IStorageStartup
    {
        void Configure(IServiceCollection services, StorageSettings storageSettings);
    }
}
