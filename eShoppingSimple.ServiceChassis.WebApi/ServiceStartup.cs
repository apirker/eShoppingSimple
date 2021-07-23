using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Events.Init;
using eShoppingSimple.ServiceChassis.Storage;
using eShoppingSimple.ServiceChassis.Storage.EfCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace eShoppingSimple.ServiceChassis.WebApi
{
    /// <summary>
    /// Service startup class to configure the webapi
    /// </summary>
    public class ServiceStartup
    {
        private readonly string serviceName;
        private readonly string serviceVersion;
        private readonly bool isDevelopment;
        private readonly IStorageStartup storageStartup;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;
        private const string swaggerPrefix = "";

        public ServiceStartup(string serviceName, string serviceVersion, bool isDevelopment, 
            IStorageStartup storageStartup, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.serviceName = serviceName;
            this.serviceVersion = serviceVersion;
            this.isDevelopment = isDevelopment;
            this.storageStartup = storageStartup;
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }

        /// <summary>
        /// Sets up the dependency injection.
        /// </summary>
        public void ConfigureServiceCollection(IServiceCollection services)
        {
            services.AddControllers(options =>
            {
                
            }).AddJsonOptions(options =>
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
            services.AddMvc();

            if (isDevelopment)
            {
                services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = serviceName, Version = serviceVersion });

                    var xmlFile = "ServiceDocumentation.xml";
                    var xmlPath = Path.Combine(webHostEnvironment.ContentRootPath, xmlFile);
                    if (File.Exists(xmlPath))
                        c.IncludeXmlComments(xmlPath);

                    c.EnableAnnotations();
                    c.CustomSchemaIds(type => Regex.Replace(type.ToString(), @"[^a-zA-Z0-9._-]+", ""));
                });
            }

            var storageSettings = GetSorageSettings(services, configuration);
            var eventSettings = GetEventSettings(services, configuration);

            if (eventSettings != null)
                services.AddEvents(eventSettings);

            if (storageStartup != null && storageSettings != null)
                storageStartup.Configure(services, storageSettings);
        }

        /// <summary>
        /// Configures the application.
        /// </summary>
        public void ConfigureApplication(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            if (isDevelopment)
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(swaggerPrefix == string.Empty
                        ? "/swagger/v1/swagger.json"
                        : $"/{swaggerPrefix}/swagger/v1/swagger.json", $"{serviceName} {serviceVersion}");
                    c.DisplayRequestDuration();
                });
            }

            storageStartup.EnsureCreated(serviceProvider);

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }

        private static StorageSettings GetSorageSettings(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            try
            {
                serviceCollection.Configure<StorageSettings>(configuration.GetSection("StorageSettings"));

                var storageSettings = serviceCollection.BuildServiceProvider().GetService<IOptions<StorageSettings>>();
                return storageSettings.Value;
            }
            catch
            {
                return null;
            }
        }

        private static EventSettings GetEventSettings(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            try
            {
                serviceCollection.Configure<EventSettings>(configuration.GetSection("EventSettings"));

                var eventSettings = serviceCollection.BuildServiceProvider().GetService<IOptions<EventSettings>>();
                return eventSettings.Value;
            }
            catch
            {
                return null;
            }
        }
    }
}
