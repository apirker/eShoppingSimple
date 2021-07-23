using Microsoft.EntityFrameworkCore;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    /// <summary>
    /// Interface which needs to be implemented to register the data model to entity framework.
    /// </summary>
    public interface IModelBuilderConfiguration
    {
        /// <summary>
        /// Method which gets invoked when the model is being build.
        /// </summary>
        void OnCreatingModels(ModelBuilder builder);
    }
}
