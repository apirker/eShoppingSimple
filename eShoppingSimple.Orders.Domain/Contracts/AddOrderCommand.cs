using eShoppingSimple.Orders.Domain.Implementations;
using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    public class AddOrderCommand : BaseCommand
    {
        private readonly Guid customerId;
        private readonly IEnumerable<(Guid itemId, string name, float price, IList<string> pictures)> items;

        public AddOrderCommand(Guid customerId, IEnumerable<(Guid itemId, string name, float price, IList<string> pictures)> items, IServiceProvider serviceProvider) : base(serviceProvider)
        {
            this.customerId = customerId;
            this.items = items;
        }

        protected override EventBundle ExecuteInternal(IUnitOfWork unitOfWork)
        {
            var order = (Order) OrderFactory.Create(Guid.NewGuid(), customerId, items);
            var orderRepository = unitOfWork.GetRepository<IOrder>();
            orderRepository.Add(order);

            return new EventBundle();
        }
    }
}
