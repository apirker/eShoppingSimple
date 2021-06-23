using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Domain
{
    public abstract class BaseCommand
    {
        private readonly IServiceProvider serviceProvider;

        public BaseCommand(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected abstract EventBundle ExecuteInternal(IUnitOfWork unitOfWork);
        
        public void Execute()
        {
            using(var unitOfWork = serviceProvider.GetService<IUnitOfWork>())
            {
                var eventBundle = ExecuteInternal(unitOfWork);
                var eventBus = serviceProvider.GetService<IEventBus>();

                eventBundle.Publish(eventBus);
                unitOfWork.Commit();
            }
        }
    }
}
