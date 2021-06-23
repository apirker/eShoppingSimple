using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    class GetOrdersCommand : BaseQuery<IOrder>
    {
        public GetOrdersCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override IEnumerable<IOrder> QueryInternal(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }
    }
}
