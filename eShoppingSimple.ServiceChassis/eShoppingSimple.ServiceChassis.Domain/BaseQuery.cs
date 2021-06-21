using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Domain
{
    public abstract class BaseQuery<T>
    {
        private IServiceProvider serviceProvider;

        public BaseQuery(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        protected abstract IEnumerable<T> QueryInternal(IUnitOfWork unitOfWork);

        public IEnumerable<T> Query()
        {
            using (var unitOfWork = serviceProvider.GetService<IUnitOfWork>())
            {
                var results = QueryInternal(unitOfWork);
                unitOfWork.SaveChanges();

                return results;
            }
        }
    }
}
