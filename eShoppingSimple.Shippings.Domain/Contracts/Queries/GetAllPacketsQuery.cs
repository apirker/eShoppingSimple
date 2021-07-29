using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Shippings.Domain.Contracts.Queries
{
    public class GetAllPacketsQuery : BaseQuery<IPacket>
    {
        public GetAllPacketsQuery(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override IEnumerable<IPacket> QueryInternal(IUnitOfWork unitOfWork)
        {
            var packetRepository = unitOfWork.GetRepository<IPacket>();
            var results = packetRepository.GetAll();

            return results.ToList();
        }
    }
}
