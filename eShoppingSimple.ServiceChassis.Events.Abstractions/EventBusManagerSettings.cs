namespace eShoppingSimple.ServiceChassis.Events.Abstractions
{
    class EventBusManagerSettings
    {   
        public string ServiceName { get; set; } = "NoName";
        public int MaxResponseWaitingTime { get; set; } = 20000;
    }
}
