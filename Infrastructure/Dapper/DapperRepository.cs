using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Infrastructure.Dapper
{
    public partial class DapperRepository<T> : IDapperRepository<T> where T : class, new()
    {
        private readonly static Dictionary<DatabaseType, IDbConnection> dic = new Dictionary<DatabaseType, IDbConnection>
        {
            [DatabaseType.SQLServer] = new SqlConnection(),
            [DatabaseType.MySQL] = new MySqlConnection(),
            [DatabaseType.SQLite] = new SqliteConnection()
        };

        private readonly DapperOptions _options;
        internal IDbConnection Connection;

        public DapperRepository(IOptions<DapperOptions> optionsAccessor)
        {
            if (optionsAccessor == null)
            {
                throw new ArgumentNullException(nameof(optionsAccessor));
            }

            _options = optionsAccessor.Value;
            Connection = dic[_options.DatabaseType];
            Connection.ConnectionString = _options.ConnectionString;
        }

        public long Insert(T entity)
        {
            return this.Connection.Insert(entity);
        }

        
    }
}
