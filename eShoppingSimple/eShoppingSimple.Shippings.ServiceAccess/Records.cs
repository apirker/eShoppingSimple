using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.ServiceAccess
{
    public record PackageDto(Guid Id, string DeliveryService, IEnumerable<OrderDto> Orders);
    public record OrderDto(Guid Id, IEnumerable<ItemDto> ItemDtos);
    public record ItemDto(Guid Id, float Weight);
}
