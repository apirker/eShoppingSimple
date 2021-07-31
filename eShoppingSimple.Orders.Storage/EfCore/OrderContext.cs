using eShoppingSimple.ServiceChassis.Storage.EfCore;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Storage.EfCore
{
    /// <summary>
    /// Database context for order extends base context.
    /// </summary>
    public class OrderContext : BaseContext
    {
        public OrderContext(IEnumerable<IModelBuilderConfiguration> modelBuilderConfigurations, StorageSettings storageSettings) 
            : base(modelBuilderConfigurations, storageSettings)
        {
        }
    }
}
