using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Events.Init;
using eShoppingSimple.ServiceChassis.Events.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;
using System.Threading;

namespace eShoppingSimple.ServiceChassis.Events.Tests
{
    [TestClass]
    public class DevTool
    {
        private class SampleEventHandler : IEventHandler
        {
            public void Handle(object @event)
            {
                var sampleEvent = (SampleEvent)@event;
                Debug.WriteLine($"Received an event! Sample event with {sampleEvent.Message}");
            }
        }

        [TestMethod]
        public void TestRabbitMq()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEvents(new EventSettings());
            serviceCollection.AddTransient<IEventCodeFactory, EventCodeFactory>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            var eventBus = serviceProvider.GetService<IEventBus>();
            eventBus.Subscribe<SampleEvent>(new SampleEventHandler());
            eventBus.Start();
            eventBus.Publish(new SampleEvent("Hey i am an event"));

            Thread.Sleep(5000);

            eventBus.Stop();
            serviceProvider.Dispose();
        }
    }
}
