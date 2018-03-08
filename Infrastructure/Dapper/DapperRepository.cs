using Dapper.Contrib.Extensions;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;

namespace Infrastructure.Dapper
{
    public partial class DapperRepository<T> : IDapperRepository<T> where T : class, new()
    {
        private readonly static Dictionary<DatabaseType, Type> dic = new Dictionary<DatabaseType, Type>
        {
            [DatabaseType.SqlServer] = typeof(SqlConnection),
            [DatabaseType.MySQL] = typeof(MySqlConnection),
            [DatabaseType.SQLite] = typeof(SqliteConnection)
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
            Type type = dic[_options.DatabaseType];
            Connection = Activator.CreateInstance(type) as IDbConnection;
            Connection.ConnectionString = _options.ConnectionString;
        }

        public long Insert(T entity)
        {
            return this.Connection.Insert(entity);
        }
    }
}
