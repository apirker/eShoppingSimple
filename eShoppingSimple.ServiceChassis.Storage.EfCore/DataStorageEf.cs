using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    /// <summary>
    /// Entity framework specific data storage implementation.
    /// </summary>
    /// <typeparam name="TStorage"></typeparam>
    public class DataStorageEf<TStorage> : IDataStorage<TStorage> where TStorage : class, IHasId
    {
        private readonly DbContext dbContext;

        public DataStorageEf(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        /// <inheritdoc />
        public void Add(TStorage storageItem)
        {
            dbContext.Set<TStorage>().Add(storageItem);
        }

        /// <inheritdoc />
        public IQueryable<TStorage> AsQueryable()
        {
            return dbContext.Set<TStorage>().AsQueryable();
        }

        /// <inheritdoc />
        public void Delete(TStorage storageItem)
        {
            dbContext.Set<TStorage>().Remove(storageItem);
        }

        /// <inheritdoc />
        public IEnumerable<TStorage> GetAll()
        {
            return dbContext.Set<TStorage>().Where(t => true);
        }

        /// <inheritdoc />
        public TStorage GetOne(Guid id)
        {
            return dbContext.Set<TStorage>().FirstOrDefault(t => t.Id == id);
        }

        /// <inheritdoc />
        public void Update(TStorage storageItem)
        {
            dbContext.Set<TStorage>().Attach(storageItem);
            dbContext.Entry(storageItem).State = EntityState.Modified;
        }

    }
}
