using System.Threading.Tasks;

namespace Infrastructure.Dapper
{
    public partial interface IDapperRepository<T> where T : class, new()
    {
        Task<int> InsertAsync(T entity);
    }
}
