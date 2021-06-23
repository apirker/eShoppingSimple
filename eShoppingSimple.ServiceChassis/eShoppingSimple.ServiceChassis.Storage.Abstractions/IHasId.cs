using System;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    public interface IHasId
    {
        Guid Id { get; set; }
    }
}
