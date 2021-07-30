namespace eShoppingSimple.Orders.ServiceAccess
{
    /// <summary>
    /// Factory class to create a new order service client.
    /// </summary>
    public class OrderServiceClientFactory
    {
        /// <summary>
        /// Factory method to create a new order service client
        /// </summary>
        public static IOrderServiceClient Create(string baseUri)
        {
            return new OrderServiceClient(baseUri);
        }
    }
}
