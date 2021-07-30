using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Linq;

namespace eShoppingSimple.Shippings.Domain.Contracts.Commands
{
    /// <summary>
    /// Command to delete a packet
    /// </summary>
    public class DeletePacketCommand : BaseCommand
    {
        private readonly Guid id;

        public DeletePacketCommand(Guid id, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.id = id;
        }

        protected override EventBundle ExecuteInternal(IUnitOfWork unitOfWork)
        {
            var packetRepository = unitOfWork.GetRepository<IPacket>();
            var packets = packetRepository.GetAll();

            var packet = packets.FirstOrDefault(p => p.Id == id);
            if (packet != null)
                packetRepository.Delete(packet);

            return new EventBundle();
        }
    }
}
