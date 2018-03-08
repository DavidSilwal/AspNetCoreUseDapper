namespace Infrastructure.Dapper
{
    public class DapperOptions
    {
        /// <summary>
        /// connection string
        /// </summary>
        public string ConnectionString { get; set; }

        /// <summary>
        /// database type
        /// </summary>
        public DatabaseType DatabaseType { get; set; } = DatabaseType.SQLServer;
    }

    public enum DatabaseType
    {
        SQLServer,
        MySQL,
        SQLite
    }
}
