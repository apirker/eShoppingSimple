namespace eShoppingSimple.ServiceChassis.Storage.Abstractions
{
    /// <summary>
    /// Mapper interface to map from domain type to storage type and vice versa.
    /// </summary>
    /// <typeparam name="TDomain"></typeparam>
    /// <typeparam name="TStorage"></typeparam>
    public interface IMapper<TDomain, TStorage>
        where TDomain : class, IHasId
        where TStorage : class, IHasId
    {
        /// <summary>
        /// Map from domain to storage type.
        /// </summary>
        TStorage Map(TDomain domain);

        /// <summary>
        /// Map from storage to domain type.
        /// </summary>
        /// <param name="storage"></param>
        /// <returns></returns>
        TDomain Map(TStorage storage);

        /// <summary>
        /// Map an existing domain object to an existing storage object. 
        /// </summary>
        void Map(TDomain source, TStorage destination);
    }
}
