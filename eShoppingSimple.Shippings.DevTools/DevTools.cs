using eShoppingSimple.Shippings.ServiceAccess;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.DevTools
{
    [TestClass]
    public class DevTools
    {
        [TestMethod]
        public async void Test()
        {
            var shippingsClient = Shippings.ServiceAccess.ShippingServiceClientFactory.Create("http://localhost:22345");
            var orderId = Guid.NewGuid();
            await shippingsClient.AddPacket(new ServiceAccess.PacketDto(orderId, "DHL", "US", new List<ItemDto>() { new ItemDto(Guid.NewGuid(), 55, new OrderDto(Guid.NewGuid())) }));
            var results = await shippingsClient.GetPackets();
            await shippingsClient.DeletePacket(orderId);
        }
    }
}
