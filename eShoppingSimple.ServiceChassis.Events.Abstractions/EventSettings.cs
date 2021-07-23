namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    /// <summary>
    /// Settings for an event bus.
    /// </summary>
    public class EventSettings
    {   
        /// <summary>
        /// Name of the service.
        /// </summary>
        public string ServiceName { get; set; } = "NoName";

        /// <summary>
        /// Maximum time to wait for a response.
        /// </summary>
        public int MaxResponseWaitingTime { get; set; } = 20000;

        /// <summary>
        /// Provider to be used.
        /// </summary>
        public string Provider { get; set; } = "RabbitMq";
    }
}
