namespace eShoppingSimple.ServiceChassis.Storage.EfCore
{
    /// <summary>
    /// Settings class for storages.
    /// </summary>
    public class StorageSettings
    {
        /// <summary>
        /// Connection string of the db in case of SQL server.
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// Type of the database.
        /// </summary>
        public DatabaseType DbType { get; set; }

        /// <summary>
        /// Name of the database.
        /// </summary>
        public string DbName { get; set; }
    }

    public enum DatabaseType
    {
        /// <summary>
        /// SQL server.
        /// </summary>
        SqlServer,

        /// <summary>
        /// In memory DB.
        /// </summary>
        InMemory
    }
}
