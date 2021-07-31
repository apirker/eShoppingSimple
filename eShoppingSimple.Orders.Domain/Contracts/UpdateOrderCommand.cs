using eShoppingSimple.Orders.Domain.Implementations;
using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    /// <summary>
    /// Command to update an order
    /// </summary>
    public class UpdateOrderCommand : BaseCommand
    {
        private readonly Guid orderId;
        private readonly IEnumerable<(Guid itemId, string name, float price, IList<string> pictures)> items;

        public UpdateOrderCommand(Guid orderId, IEnumerable<(Guid itemId, string name, float price, IList<string> pictures)> items, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.orderId = orderId;
            this.items = items;
        }

        protected override EventBundle ExecuteInternal(IUnitOfWork unitOfWork)
        {
            var orderRepository = unitOfWork.GetRepository<IOrder>();
            var orders = orderRepository.GetAll();
            var order = orders.FirstOrDefault(o => o.Id == orderId);

            if(order!= null)
            {
                ((Order)order).ChangeItems(items);
                orderRepository.Update(order);
            }

            return new EventBundle();
        }
    }
}
