using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShoppingSimple.Shippings.ServiceAccess
{
    /// <summary>
    /// Interface of a client to access the shipping service
    /// </summary>
    public interface IShippingServiceClient
    {
        /// <summary>
        /// Returns all packets in the shipping service
        /// </summary>
        Task<IEnumerable<PacketDto>> GetPackets();

        /// <summary>
        /// Adds a packet to the shipping service
        /// </summary>
        Task AddPacket(PacketDto dto);

        /// <summary>
        /// Deletes a packet from the service
        /// </summary>
        Task DeletePacket(Guid packetId);
    }
}
