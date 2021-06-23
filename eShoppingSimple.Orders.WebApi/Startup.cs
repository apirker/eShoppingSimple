using eShoppingSimple.Orders.Storage;
using eShoppingSimple.ServiceChassis.WebApi;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShoppingSimple.Orders.WebApi
{
    public class Startup
    {
        private readonly ServiceStartup serviceStartup;
        public Startup(IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            Configuration = configuration;
            serviceStartup = new ServiceStartup("OrderService", "1.0.0", true, OrderStorageInitializer.CreateStorageStartup(), configuration, webHostEnvironment);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddStorageMapper();
            serviceStartup.ConfigureServiceCollection(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            serviceStartup.ConfigureApplication(app, serviceProvider);
        }
    }
}
