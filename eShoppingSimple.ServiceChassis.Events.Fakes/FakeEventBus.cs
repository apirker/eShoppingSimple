using eShoppingSimple.ServiceChassis.Events.Abstractions;

namespace eShoppingSimple.ServiceChassis.Events.Fakes
{
    public class FakeEventBus : IEventBus
    {
        public void Publish<T>(T @event) where T : IEvent
        {
            //would forward the event to some provider
        }

        public void Subscribe<T>(IEventHandler<T> eventHandler) where T : IEvent
        {
            //would subscribe to a provider
        }

        public void Unsubscribe<T>(IEventHandler<T> eventHandler) where T : IEvent
        {
            //would unsubscribe from a provider
        }
    }
}
