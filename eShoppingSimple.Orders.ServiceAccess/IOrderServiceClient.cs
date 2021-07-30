using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShoppingSimple.Orders.ServiceAccess
{
    /// <summary>
    /// Service client interface for applications to interact with the order service.
    /// </summary>
    public interface IOrderServiceClient
    {
        /// <summary>
        /// Adding an order
        /// </summary>
        Task<Guid> AddOrder(Guid customerId, IEnumerable<ItemDto> itemDtos);

        /// <summary>
        /// Updating an order
        /// </summary>
        Task UpdateOrder(Guid orderId, IEnumerable<ItemDto> itemDtos);

        /// <summary>
        /// Deleting an order
        /// </summary>
        Task DeleteOrder(Guid orderId);

        /// <summary>
        /// Get an order by its id
        /// </summary>
        Task<OrderDto> GetOrder(Guid id);

        /// <summary>
        /// Get all orders
        /// </summary>
        Task<IEnumerable<OrderDto>> GetOrders();


    }
}
