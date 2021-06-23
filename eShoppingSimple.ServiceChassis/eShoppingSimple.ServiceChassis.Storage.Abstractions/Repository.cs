using System.Collections.Generic;
using System.Linq;

namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    public class Repository<TDomain, TStorage> : IRepository<TDomain> 
        where TDomain : class, IHasId
        where TStorage : class, IHasId
    {
        private readonly IMapper<TDomain, TStorage> mapper;
        private readonly IDataStorage<TStorage> dataStorage;

        public Repository(IMapper<TDomain, TStorage> mapper, IDataStorage<TStorage> dataStorage)
        {
            this.mapper = mapper;
            this.dataStorage = dataStorage;
        }
        public void Add(TDomain item)
        {
            var data = mapper.Map(item);
            dataStorage.Add(data);
        }

        public void Delete(TDomain item)
        {
            var data = mapper.Map(item);
            dataStorage.Delete(data);
        }

        public IEnumerable<TDomain> GetAll()
        {
            var items = dataStorage.GetAll();
            return items.Select(i => mapper.Map(i));
        }

        public void Update(TDomain item)
        {
            var data = mapper.Map(item);
            dataStorage.Update(data);
        }
    }
}
