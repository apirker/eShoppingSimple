using eShoppingSimple.ServiceChassis.Storage.EfCore;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Storage.EfCore
{
    /// <summary>
    /// Database context for the packet database.
    /// </summary>
    class PacketContext : BaseContext
    {
        public PacketContext(IEnumerable<IModelBuilderConfiguration> modelBuilderConfigurations, StorageSettings storageSettings) : 
            base(modelBuilderConfigurations, storageSettings)
        {
        }
    }
}
