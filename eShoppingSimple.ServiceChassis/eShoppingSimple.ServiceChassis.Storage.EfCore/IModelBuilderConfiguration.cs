using Microsoft.EntityFrameworkCore;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    public interface IModelBuilderConfiguration
    {
        void OnCreatingModels(ModelBuilder builder);
    }
}
