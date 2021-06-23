namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    public class StorageSettings
    {
        public string ConnectionString { get; set; }

        public DatabaseType DbType { get; set; }

        public string DbName { get; set; }
    }

    public enum DatabaseType
    {
        
        SqlServer,
        InMemory
    }
}
