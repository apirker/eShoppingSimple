namespace eShoppingSimple.Orders.ServiceAccess
{
    public class OrderServiceClientFactory
    {
        public static IOrderServiceClient Create(string baseUri)
        {
            return new OrderServiceClient(baseUri);
        }
    }
}
