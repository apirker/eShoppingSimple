using eShoppingSimple.ServiceChassis.WebApi;
using eShoppingSimple.Shippings.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShoppingSimple.Shippings.WebApi
{
    /// <summary>
    /// Startup class for the shipping service.
    /// </summary>
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            serviceStartup = new ServiceStartup("ShippingService", "1.0.0", true, ShippingStorageInitializer.CreateStorageStartup(), configuration, webHostEnvironment);
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

        private ServiceStartup serviceStartup;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorageMapper();
            serviceStartup.ConfigureServiceCollection(services);
        }

        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            serviceStartup.ConfigureApplication(app, serviceProvider);
        }
    }
}
