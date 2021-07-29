using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.ServiceAccess
{
    public record PacketDto(Guid Id, string DeliveryService, string Destination, IEnumerable<ItemDto> Items);
    public record ItemDto(Guid Id, float Weight, OrderDto Order);
    public record OrderDto(Guid Id);
}
