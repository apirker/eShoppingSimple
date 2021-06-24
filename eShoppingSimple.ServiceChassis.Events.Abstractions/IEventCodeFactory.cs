using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public interface IEventCodeFactory
    {
        string GetEventCode(Type type);
        Type GetEventType(string code);
    }
}
