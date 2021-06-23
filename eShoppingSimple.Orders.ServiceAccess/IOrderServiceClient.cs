using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.ServiceAccess
{
    public interface IOrderServiceClient
    {
        Guid AddOrder(Guid customerId, IEnumerable<ItemDto> itemDtos);
        void UpdateOrder(Guid orderId, IEnumerable<ItemDto> itemDtos);
        void DeleteOrder(Guid orderId);

        OrderDto GetOrder(Guid id);

    }
}
