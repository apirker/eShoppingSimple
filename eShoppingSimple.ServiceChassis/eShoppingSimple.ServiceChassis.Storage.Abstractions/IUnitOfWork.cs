using System;
using System.Threading.Tasks;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> GetRepository<T>() where T : class, IHasId;

        void Commit();
    }
}
