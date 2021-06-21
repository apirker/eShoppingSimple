using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.ServiceAccess
{
    public record OrderDto(IEnumerable<ItemDto> Items);

    public record ItemDto(Guid Id, string Name, float Price);
}
