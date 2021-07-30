using eShoppingSimple.Orders.Domain.Implementations;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    /// <summary>
    /// Static factory class to create orders.
    /// </summary>
    public static class OrderFactory
    {
        /// <summary>
        /// Factory method for creating orders.
        /// </summary>
        public static IOrder Create(Guid orderId, Guid customerId, IEnumerable<(Guid itemId, string name, float price, IList<string> pictures)> items)
        {
            return new Order(orderId, customerId, items);
        }
    }
}
