namespace eShoppingSimple.Shippings.ServiceAccess
{
    public static class ShippingServiceClientFactory
    {
        public static IShippingServiceClient Create(string baseUri)
        {
            return new ShippingServiceClient(baseUri);
        }
    }
}
