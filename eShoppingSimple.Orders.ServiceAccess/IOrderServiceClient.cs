using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShoppingSimple.Orders.ServiceAccess
{
    public interface IOrderServiceClient
    {
        Task<Guid> AddOrder(Guid customerId, IEnumerable<ItemDto> itemDtos);
        Task UpdateOrder(Guid orderId, IEnumerable<ItemDto> itemDtos);
        Task DeleteOrder(Guid orderId);

        Task<OrderDto> GetOrder(Guid id);
        Task<IEnumerable<OrderDto>> GetOrders();


    }
}
