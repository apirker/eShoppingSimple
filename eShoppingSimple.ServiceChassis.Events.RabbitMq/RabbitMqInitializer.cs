using eShoppingSimple.ServiceChassis.Events.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Events.RabbitMq
{
    public static class RabbitMqInitializer
    {
        public static void AddRabbitMqConnector(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IEventBusConnector, RabbitMqConnector>();
            serviceCollection.AddSingleton<RabbitMqOptions>();
        }
    }
}
