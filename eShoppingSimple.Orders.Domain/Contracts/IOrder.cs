using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    /// <summary>
    /// Data interface of orders
    /// </summary>
    public interface IOrder : IHasId
    {
        /// <summary>
        /// Id of the customer of this order
        /// </summary>
        Guid CustomerId { get; }

        /// <summary>
        /// Items of this order
        /// </summary>
        IEnumerable<IItem> Items { get; }
    }
}
