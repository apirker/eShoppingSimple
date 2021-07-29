using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Domain.Contracts
{
    public interface IPacket : IHasId
    {
        Guid Id { get; }

        string Destination { get; }

        string DeliveryService { get; }

        float TotalWeight { get; }

        IList<IItem> Items { get; }
    }
}
