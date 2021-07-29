using eShoppingSimple.ServiceChassis.WebApi;
using eShoppingSimple.Shippings.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShoppingSimple.Shippings.WebApi
{
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorageMapper();
            serviceStartup.ConfigureServiceCollection(services);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        /// <param name="serviceProvider"></param>
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            serviceStartup.ConfigureApplication(app, serviceProvider);
        }
    }
}
