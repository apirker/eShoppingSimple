using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Events.Fakes;
using eShoppingSimple.ServiceChassis.Events.RabbitMq;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Events.Init
{
    /// <summary>
    /// Class used for initializing the event bus.
    /// </summary>
    public static class EventInitializer
    {
        /// <summary>
        /// Extension method to add the support for event bus to the dependency injection framework.
        /// </summary>
        public static void AddEvents(this IServiceCollection serviceCollection, EventSettings eventSettings)
        {
            if(eventSettings.Provider == "RabbitMq")
            {
                serviceCollection.AddSingleton<IEventBus, EventBus>();
                serviceCollection.AddRabbitMqConnector();
            }
            else
            {
                serviceCollection.AddSingleton<IEventBus, FakeEventBus>();
            }
            serviceCollection.AddSingleton(eventSettings);
        }
    }
}
