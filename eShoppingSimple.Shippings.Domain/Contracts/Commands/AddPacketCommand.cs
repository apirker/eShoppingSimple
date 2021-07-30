using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Shippings.Domain.Contracts.Commands
{
    /// <summary>
    /// Command to add a packet
    /// </summary>
    public class AddPacketCommand : BaseCommand
    {
        private readonly Guid id;
        private readonly string destination;
        private readonly string deliveryService;
        private readonly IList<(Guid id, float weight, Guid orderId)> items;

        public AddPacketCommand(Guid id, string destination, string deliveryService, IList<(Guid id, float weight, Guid orderId)> items, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.id = id;
            this.destination = destination;
            this.deliveryService = deliveryService;
            this.items = items;
        }

        protected override EventBundle ExecuteInternal(IUnitOfWork unitOfWork)
        {
            var packetRepository = unitOfWork.GetRepository<IPacket>();
            var packet = PacketFactory.Create(id, destination, deliveryService, items);

            packetRepository.Add(packet);
            return new EventBundle();
        }
    }
}
