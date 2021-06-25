namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    public class EventSettings
    {   
        public string ServiceName { get; set; } = "NoName";
        public int MaxResponseWaitingTime { get; set; } = 20000;
        public string Provider { get; set; } = "RabbitMq";
    }
}
