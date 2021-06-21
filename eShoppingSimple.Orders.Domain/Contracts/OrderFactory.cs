using eShoppingSimple.Orders.Domain.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    public static class OrderFactory
    {
        public static IOrder Create(Guid orderId, Guid customerId, IEnumerable<(Guid itemId, string name, float price)> items)
        {
            return new Order(orderId, customerId, items);
        }
    }
}
