using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace eShoppingSimple.Shippings.ServiceAccess
{
    public interface IShippingServiceClient
    {
        Task<IEnumerable<PacketDto>> GetPackets();

        Task AddPacket(PacketDto dto);

        Task DeletePacket(Guid packetId);
    }
}
