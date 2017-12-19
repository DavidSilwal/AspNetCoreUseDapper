using Dapper.Contrib.Extensions;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Repository.Dapper
{
    public partial class Repository<T> : IRepository<T> where T : class, new()
    {
        private string connectionString;
        public Repository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnectionString");
        }

        internal IDbConnection Connection
        {
            get
            {
                return new SqlConnection(connectionString);
            }
        }

        public long Insert(T entity)
        {
            return this.Connection.Insert(entity);
        }
        public bool Delete(T entity)
        {
            return this.Connection.Delete(entity);
        }
        public bool Update(T entity)
        {
            return this.Connection.Update(entity);
        }
        public T Get(object id)
        {
            return this.Connection.Get<T>(id);
        }
    }
}
