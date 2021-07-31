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
    /// Startup class for the web api.
    /// </summary>
    public class Startup
    {
        private readonly ServiceStartup serviceStartup;

        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            serviceStartup = new ServiceStartup("OrderService", "1.0.0", true, OrderStorageInitializer.CreateStorageStartup(), configuration, webHostEnvironment);
        }

        public IConfiguration Configuration { get; }

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
