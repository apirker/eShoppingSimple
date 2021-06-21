using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.Storage
{
    public class StorageStartup
    {
        public void Configure(IServiceCollection serviceCollection, IConfiguration configuration)
        {

        }

        public void PrepareDatabase(IServiceScope serviceScope, bool isDevelopment)
        {

        }
    }
}
