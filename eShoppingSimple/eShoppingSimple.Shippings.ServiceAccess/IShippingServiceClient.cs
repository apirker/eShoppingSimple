using System.Collections.Generic;

namespace eShoppingSimple.Shippings.ServiceAccess
{
    public interface IShippingServiceClient
    {
        IEnumerable<PackageDto> GetPackages();
    }
}
