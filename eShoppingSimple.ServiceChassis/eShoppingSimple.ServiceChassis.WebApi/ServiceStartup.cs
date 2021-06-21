using eShoppingSimple.ServiceChassis.Storage;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.WebApi
{
    class ServiceStartup
    {
        private readonly string serviceName;
        private readonly string serviceVersion;
        private readonly bool isDevelopment;
        private readonly StorageStartup storageStartup;
        private readonly IConfiguration configuration;
        private readonly IWebHostEnvironment webHostEnvironment;
        private const string swaggerPrefix = "swagger";

        public ServiceStartup(string serviceName, string serviceVersion, bool isDevelopment, 
            StorageStartup storageStartup, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            this.serviceName = serviceName;
            this.serviceVersion = serviceVersion;
            this.isDevelopment = isDevelopment;
            this.storageStartup = storageStartup;
            this.configuration = configuration;
            this.webHostEnvironment = webHostEnvironment;
        }
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

            if (storageStartup != null)
                storageStartup.Configure(services, configuration);
        }

        public void ConfigureApplication(IApplicationBuilder app, IServiceProvider serviceProvider)
        {
            //prepare the database of the service.
            if (storageStartup != null)
                storageStartup.PrepareDatabase(serviceProvider.CreateScope(), isDevelopment);

            if (isDevelopment)
            {
                app.UseSwagger();

                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(swaggerPrefix == string.Empty
                        ? "/swagger/v1/swagger.json"
                        : $"/{swaggerPrefix}/swagger/v1/swagger.json", $"{serviceName} {serviceVersion }");
                    c.DisplayRequestDuration();
                });
            }

            app.UseRouting();
            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
    }
}
