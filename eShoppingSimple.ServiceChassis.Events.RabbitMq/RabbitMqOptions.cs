namespace eShoppingSimple.ServiceChassis.Events.RabbitMq
{
    /// <summary>
    /// Options class for the RabbitMQ connector.
    /// </summary>
    public class RabbitMqOptions
    {
        public string Host { get; set; } = "localhost";
        
        public int Port { get; set; } = 5672;

        public uint PrefetchSize { get; set; } = 0;

        public ushort PrefetchCount { get; set; } = 5;

        public bool GlobalPrefetch { get; set; } = false;

        public string BrokerName { get; set; } = "Exchange";

        public bool IsRequeuedOnRetry { get; set; } = false;
    }
}
