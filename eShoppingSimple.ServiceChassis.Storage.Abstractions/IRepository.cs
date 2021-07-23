using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    /// <summary>
    /// Interface which abstracts how to access storages from the domains perspective.
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    public interface IRepository<TDomain> where TDomain : class, IHasId
    {
        /// <summary>
        /// Add a domain object.
        /// </summary>
        void Add(TDomain item);

        /// <summary>
        /// Delete a domain object.
        /// </summary>
        void Delete(TDomain item);

        /// <summary>
        /// Update a domain object.
        /// </summary>
        void Update(TDomain item);

        /// <summary>
        /// Returns all domain objects.
        /// </summary>
        IEnumerable<TDomain> GetAll();
    }
}
