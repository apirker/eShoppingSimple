using eShoppingSimple.ServiceChassis.Events.Abstractions;

namespace eShoppingSimple.ServiceChassis.Events.Fakes
{
    public class FakeEventBus : IEventBus
    {
        public void Publish<T>(T @event) where T : IEvent
        {
        }

        public void Start()
        {
        }

        public void Stop()
        {
        }

        public void Subscribe<T>(IEventHandler eventHandler) where T : IEvent
        {
        }

        public void Unsubscribe<T>(IEventHandler eventHandler) where T : IEvent
        {
        }
    }
}
