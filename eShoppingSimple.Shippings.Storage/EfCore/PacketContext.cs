using eShoppingSimple.ServiceChassis.Storage.EfCore;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Storage.EfCore
{
    class PacketContext : BaseContext
    {
        public PacketContext(IEnumerable<IModelBuilderConfiguration> modelBuilderConfigurations, StorageSettings storageSettings) : 
            base(modelBuilderConfigurations, storageSettings)
        {
        }
    }
}
