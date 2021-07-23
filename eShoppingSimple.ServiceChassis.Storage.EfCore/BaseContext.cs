using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    /// <summary>
    /// Base context which needs to be implemented then in the project for specific databases.
    /// </summary>
    public class BaseContext : DbContext
    {
        private readonly IEnumerable<IModelBuilderConfiguration> modelBuilderConfigurations;
        private readonly StorageSettings storageSettings;

        public BaseContext(IEnumerable<IModelBuilderConfiguration> modelBuilderConfigurations, StorageSettings storageSettings)
        {
            this.modelBuilderConfigurations = modelBuilderConfigurations;
            this.storageSettings = storageSettings;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var modelBuilderConfiguration in modelBuilderConfigurations)
            {
                modelBuilderConfiguration.OnCreatingModels(modelBuilder);
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            switch (storageSettings.DbType)
            {
                case DatabaseType.InMemory:
                    dbContextOptionsBuilder.UseInMemoryDatabase(storageSettings.DbName);
                    break;
                case DatabaseType.SqlServer:
                default:
                    dbContextOptionsBuilder.UseSqlServer(storageSettings.ConnectionString);
                    break;
            }

            base.OnConfiguring(dbContextOptionsBuilder);
        }
    }
}
