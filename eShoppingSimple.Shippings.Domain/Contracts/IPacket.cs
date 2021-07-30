using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Domain.Contracts
{
    /// <summary>
    /// Data interface of a packet
    /// </summary>
    public interface IPacket : IHasId
    {
        /// <summary>
        /// Destination of the packet
        /// </summary>
        string Destination { get; }

        /// <summary>
        /// Delivery service of the packet
        /// </summary>
        string DeliveryService { get; }

        /// <summary>
        /// Total weight of the packet
        /// </summary>
        float TotalWeight { get; }

        /// <summary>
        /// Items within the packet
        /// </summary>
        IList<IItem> Items { get; }
    }
}
