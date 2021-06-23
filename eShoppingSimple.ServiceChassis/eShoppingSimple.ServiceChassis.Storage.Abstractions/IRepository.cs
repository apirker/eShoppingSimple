using System.Collections.Generic;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    public interface IRepository<TDomain> where TDomain : class, IHasId
    {
        void Add(TDomain item);

        void Delete(TDomain item);

        void Update(TDomain item);

        IEnumerable<TDomain> GetAll();
    }
}
