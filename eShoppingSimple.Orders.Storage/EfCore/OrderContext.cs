using eShoppingSimple.ServiceChassis.Storage.EfCore;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Storage.EfCore
{
    public class OrderContext : BaseContext
    {
        public OrderContext(IEnumerable<IModelBuilderConfiguration> modelBuilderConfigurations, StorageSettings storageSettings) 
            : base(modelBuilderConfigurations, storageSettings)
        {
        }
    }
}
