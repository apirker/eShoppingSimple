using eShoppingSimple.ServiceChassis.Domain;
using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;

namespace eShoppingSimple.Orders.Domain.Contracts
{
    class UpdateOrderCommand : BaseCommand
    {
        public UpdateOrderCommand(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override EventBundle ExecuteInternal(IUnitOfWork unitOfWork)
        {
            throw new NotImplementedException();
        }
    }
}
