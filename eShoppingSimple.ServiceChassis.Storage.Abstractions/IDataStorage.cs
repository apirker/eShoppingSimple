using System;
using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    /// <summary>
    /// Interface which data storage need to implement.
    /// </summary>
    /// <typeparam name="TStorage"></typeparam>
    public interface IDataStorage<TStorage> where TStorage : class, IHasId
    {
        /// <summary>
        /// Add a data item to the storage.
        /// </summary>
        void Add(TStorage storageItem);

        /// <summary>
        /// Update a data item in the storage.
        /// </summary>
        void Update(TStorage storageItem);

        /// <summary>
        /// Delete a data item from the storage.
        /// </summary>
        void Delete(TStorage storageItem);

        /// <summary>
        /// Returns all items of the storage.
        /// </summary>
        IEnumerable<TStorage> GetAll();

        /// <summary>
        /// Find one data item by its id.
        /// </summary>        
        TStorage GetOne(Guid id);
    }
}
