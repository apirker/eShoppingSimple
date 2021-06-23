using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
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
