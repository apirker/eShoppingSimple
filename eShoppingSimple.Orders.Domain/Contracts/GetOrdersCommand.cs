using eShoppingSimple.Orders.Domain.Implementations;
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
            var orderRepository = unitOfWork.GetRepository<Order>();
            return orderRepository.GetAll();
        }
    }
}
