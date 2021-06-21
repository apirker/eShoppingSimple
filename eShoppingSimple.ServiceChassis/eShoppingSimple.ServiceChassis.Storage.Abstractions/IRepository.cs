using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    public interface IRepository<T> where T : class
    {
        void Add(T item);

        void Delete(T item);

        void Update(T item);

        IEnumerable<T> GetAll();
    }
}
