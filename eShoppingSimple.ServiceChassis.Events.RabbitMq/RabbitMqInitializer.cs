using eShoppingSimple.ServiceChassis.Events.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Events.RabbitMq
{
    /// <summary>
    /// Class to initialize RabbitMQ.
    /// </summary>
    public static class RabbitMqInitializer
    {
        /// <summary>
        /// Extension method to add the support for RabbitMQ to the dependency injection framework.
        /// </summary>
        public static void AddRabbitMqConnector(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEventBusConnector, RabbitMqConnector>();
            serviceCollection.AddSingleton<RabbitMqOptions>();
        }
    }
}
