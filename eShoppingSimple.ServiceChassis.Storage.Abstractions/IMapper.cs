namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    public interface IMapper<TDomain, TStorage>
        where TDomain : class, IHasId
        where TStorage : class, IHasId
    {
        TStorage Map(TDomain domain);

        TDomain Map(TStorage storage);

        void Map(TDomain source, TStorage destination);
    }
}
