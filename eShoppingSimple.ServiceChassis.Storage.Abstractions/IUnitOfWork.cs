using System;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    /// <summary>
    /// Transaction abstraction interface in form of a unit of work.
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// Get a repository as part of this transaction.
        /// </summary>
        IRepository<T> GetRepository<T>() where T : class, IHasId;

        /// <summary>
        /// Commit this unit of work to the database.
        /// </summary>
        void Commit();
    }
}
