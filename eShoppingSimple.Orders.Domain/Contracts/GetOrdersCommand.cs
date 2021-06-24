using eShoppingSimple.Orders.Domain.Implementations;
using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    public class GetOrdersCommand : BaseQuery<IOrder>
    {
        public GetOrdersCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override IEnumerable<IOrder> QueryInternal(IUnitOfWork unitOfWork)
        {
            var orderRepository = unitOfWork.GetRepository<IOrder>();
            var orders = orderRepository.GetAll();

            return orders.ToList();
        }
    }
}
