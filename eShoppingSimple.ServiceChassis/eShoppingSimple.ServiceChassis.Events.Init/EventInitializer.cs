using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Events.Fakes;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Events.Init
{
    public static class EventInitializer
    {
        public static void AddEvents(this IServiceCollection serviceCollection, EventSettings eventSettings)
        {
            serviceCollection.AddSingleton<IEventBus, FakeEventBus>();
            serviceCollection.AddSingleton(eventSettings);
        }
    }
}
