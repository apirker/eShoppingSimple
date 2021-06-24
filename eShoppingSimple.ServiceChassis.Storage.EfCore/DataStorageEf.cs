using eShoppingSimple.ServiceChassis.Storage.Abstractions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    public class DataStorageEf<TStorage> : IDataStorage<TStorage> where TStorage : class, IHasId
    {
        private readonly DbContext dbContext;

        public DataStorageEf(DbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TStorage storageItem)
        {
            dbContext.Set<TStorage>().Add(storageItem);
        }

        public void Delete(TStorage storageItem)
        {
            dbContext.Set<TStorage>().Remove(storageItem);
        }

        public IEnumerable<TStorage> GetAll()
        {
            return dbContext.Set<TStorage>().Where(t => true);
        }

        public TStorage GetOne(Guid id)
        {
            return dbContext.Set<TStorage>().FirstOrDefault(t => t.Id == id);
        }

        public void Update(TStorage storageItem)
        {
            dbContext.Set<TStorage>().Attach(storageItem);
            dbContext.Entry(storageItem).State = EntityState.Modified;
        }

    }
}
