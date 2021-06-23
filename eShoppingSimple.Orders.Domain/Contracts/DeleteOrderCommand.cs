using eShoppingSimple.Orders.Domain.Implementations;
using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Linq;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    class DeleteOrderCommand : BaseCommand
    {
        private readonly Guid orderId;

        public DeleteOrderCommand(Guid orderId, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.orderId = orderId;
        }

        protected override EventBundle ExecuteInternal(IUnitOfWork unitOfWork)
        {
            var orderRepository = unitOfWork.GetRepository<Order>();
            var orders = orderRepository.GetAll();
            var order = orders.FirstOrDefault(o => o.Id == orderId);

            if (order != null)
                orderRepository.Delete(order);

            return new EventBundle();
        }
    }
}
