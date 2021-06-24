using eShoppingSimple.Orders.Storage;
using eShoppingSimple.ServiceChassis.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShoppingSimple.Orders.WebApi
{
    /// <summary>
    /// 
    /// </summary>
    public class Startup
    {
        private readonly ServiceStartup serviceStartup;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="configuration"></param>
        /// <param name="webHostEnvironment"></param>
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            serviceStartup = new ServiceStartup("OrderService", "1.0.0", true, OrderStorageInitializer.CreateStorageStartup(), configuration, webHostEnvironment);
        }

        /// <summary>
        /// 
        /// </summary>
        public IConfiguration Configuration { get; }

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
