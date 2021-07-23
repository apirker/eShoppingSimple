using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using System;
using System.Collections.Generic;
using Microsoft.Extensions.DependencyInjection;

namespace eShoppingSimple.ServiceChassis.Domain
{
    /// <summary>
    /// Base query implementation for querying the domain.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseQuery<T>
    {
        private IServiceProvider serviceProvider;

        public BaseQuery(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        /// <summary>
        /// Query implementation to be implemented.
        /// </summary>
        protected abstract IEnumerable<T> QueryInternal(IUnitOfWork unitOfWork);

        /// <summary>
        /// Domain query execution.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<T> Query()
        {
            using (var unitOfWork = serviceProvider.GetService<IUnitOfWork>())
            {
                var results = QueryInternal(unitOfWork);
                unitOfWork.Commit();

                return results;
            }
        }
    }
}
