using Dapper.Contrib.Extensions;
using System.Threading.Tasks;

namespace Infrastructure.Dapper
{
    public partial class DapperRepository<T> : IDapperRepository<T> where T : class, new()
    {
        public async Task<int> InsertAsync(T entity)
        {
            return await this.Connection.InsertAsync(entity);
        }
    }
}
