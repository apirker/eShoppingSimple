using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Events.Init;
using eShoppingSimple.ServiceChassis.Events.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Threading;

namespace eShoppingSimple.ServiceChassis.Events.Tests
{
    [TestClass]
    public class DevTool
    {
        private class SampleRequestEventHandler : IEventHandler
        {
            private readonly IEventBus eventBus;

            public SampleRequestEventHandler(IEventBus eventBus)
            {
                this.eventBus = eventBus;
            }
            public void Handle(object @event)
            {   
                var s = (SampleRequestEvent)@event;
                var r = new SampleResponseEvent(Guid.NewGuid(), s.EventId, $"Message was: {s.Message}") ;

                eventBus.Publish(r);
            }
        }


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

        [TestMethod]
        public void TestRequestResponseRabbitMq()
        {
            var serviceProvider1 = GetServiceProvider("Service1");
            var serviceProvider2 = GetServiceProvider("Service2");

            var eventBus1 = serviceProvider1.GetService<IEventBus>();
            var eventBus2 = serviceProvider2.GetService<IEventBus>();

            eventBus2.Subscribe<SampleRequestEvent>(new SampleRequestEventHandler(eventBus2));

            eventBus1.Start();
            eventBus2.Start();

            Thread.Sleep(1000);

            var result = eventBus1.PublishRequestAndWait<SampleRequestEvent, SampleResponseEvent>(new SampleRequestEvent("Hey i am an event", Guid.NewGuid()));
            Debug.WriteLine($"{result.Response}");

            eventBus1.Stop();
            eventBus2.Stop();

        }

        private ServiceProvider GetServiceProvider(string serviceName)
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddEvents(new EventSettings() { ServiceName = serviceName });
            serviceCollection.AddTransient<IEventCodeFactory, EventCodeFactory>();

            var serviceProvider = serviceCollection.BuildServiceProvider();
            return serviceProvider;
        }
    }
}
