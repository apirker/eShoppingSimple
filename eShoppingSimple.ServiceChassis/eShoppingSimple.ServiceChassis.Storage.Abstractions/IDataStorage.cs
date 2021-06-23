using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    public interface IDataStorage<TStorage> where TStorage : class, IHasId
    {
        void Add(TStorage storageItem);

        void Update(TStorage storageItem);

        void Delete(TStorage storageItem);

        IEnumerable<TStorage> GetAll();
    }
}
