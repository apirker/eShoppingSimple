using System;

namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Event args which get constructed when a new event has happened.
    /// </summary>
    public class MessageArgs : EventArgs
    {
        
        public MessageArgs(string @event, string jsonArgs, ulong messageIdentifier)
        {
            MessageIdentifier = messageIdentifier;
            Event = @event;
            JsonArgs = jsonArgs;
        }

        public string Event { get; }

        public string JsonArgs { get; }
        
        public ulong MessageIdentifier { get; }

    }
}
