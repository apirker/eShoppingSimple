using eShoppingSimple.Shippings.Domain.Implementations;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Domain.Contracts
{
    /// <summary>
    /// Factory class to create packets
    /// </summary>
    public static class PacketFactory
    {
        /// <summary>
        /// Factory method to create packets.
        /// </summary>
        public static IPacket Create(Guid id, string destination, string deliveryService, IList<(Guid id, float weight, Guid orderId)> items)
        {
            return new Packet(id, destination, deliveryService, items);
        }
    }
}
