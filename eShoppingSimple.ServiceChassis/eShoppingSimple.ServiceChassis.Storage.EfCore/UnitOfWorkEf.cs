using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    internal class UnitOfWorkEf : IUnitOfWork
    {
        private readonly IServiceScope serviceScope;
        private readonly DbContext dbContext;
        private bool disposedValue;

        public UnitOfWorkEf(IServiceProvider serviceProvider)
        {
            serviceScope = serviceProvider.CreateScope();
            dbContext = serviceScope.ServiceProvider.GetRequiredService<DbContext>();
        }

        public IRepository<TDomain> GetRepository<TDomain>() where TDomain : class, IHasId
        {
            return serviceScope.ServiceProvider.GetService<IRepository<TDomain>>();
        }

        public void Commit()
        {
            dbContext.SaveChanges();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    serviceScope.Dispose();
                }

                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
