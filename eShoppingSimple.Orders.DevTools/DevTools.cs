using eShoppingSimple.Orders.ServiceAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.DevTools
{
    [TestClass]
    public class DevTools
    {
        [TestMethod]
        public async void Test()
        {
            var client = Orders.ServiceAccess.OrderServiceClientFactory.Create("http://localhost:35990");
            var orderId = Guid.NewGuid();
            await client.AddOrder(orderId, new List<ItemDto>() { new ItemDto(Guid.NewGuid(), "nothing", 1, new List<string>() { "pic" }) });
            var results = client.GetOrders();
            await client.DeleteOrder(orderId);
        }
    }
}
