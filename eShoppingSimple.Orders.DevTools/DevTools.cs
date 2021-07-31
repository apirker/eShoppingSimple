using eShoppingSimple.Orders.ServiceAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.DevTools
{
    [TestClass]
    public class DevTools
    {
        [TestMethod]
        public void Test()
        {
            var client = Orders.ServiceAccess.OrderServiceClientFactory.Create("http://localhost:35990");
            client.AddOrder(Guid.NewGuid(), new List<ItemDto>() { new ItemDto(Guid.NewGuid(), "nothing", 1, new List<string>() { "pic" }) }).GetAwaiter().GetResult();
            var results = client.GetOrders().GetAwaiter().GetResult();
            client.DeleteOrder(results.First().Id).GetAwaiter().GetResult();
        }
    }
}
