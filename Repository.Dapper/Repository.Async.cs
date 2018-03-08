using System.Threading.Tasks;

namespace Repository.Dapper
{
    public partial class Repository<T> : IRepository<T> where T : class, new()
    {
        
    }
}
