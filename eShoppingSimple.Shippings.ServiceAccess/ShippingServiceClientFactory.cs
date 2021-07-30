namespace eShoppingSimple.Shippings.ServiceAccess
{
    /// <summary>
    /// Factory class to create a shipping service client
    /// </summary>
    public static class ShippingServiceClientFactory
    {
        /// <summary>
        /// Factory method to create a new shipping service client
        /// </summary>
        public static IShippingServiceClient Create(string baseUri)
        {
            return new ShippingServiceClient(baseUri);
        }
    }
}
