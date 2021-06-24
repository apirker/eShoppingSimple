using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.ServiceAccess
{
    public record ResultOrderDto(Guid Id, Guid CustomerId, IEnumerable<ItemDto> Items);

    public record OrderDto(Guid CustomerId, IEnumerable<ItemDto> Items);

    public record ItemDto(Guid Id, string Name, float Price, IList<string> Pictures);
}
