using eShoppingSimple.ServiceChassis.Events.Abstractions;
using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Domain
{
    /// <summary>
    /// Base command implementation for domain commands.
    /// </summary>
    public abstract class BaseCommand
    {
        private readonly IServiceProvider serviceProvider;

        public BaseCommand(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Method which really executes the command logic.
        /// </summary>
        protected abstract EventBundle ExecuteInternal(IUnitOfWork unitOfWork);
        
        /// <summary>
        /// Execuction of a domain command.
        /// </summary>
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
