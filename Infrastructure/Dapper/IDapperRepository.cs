namespace Infrastructure.Dapper
{
    public partial interface IDapperRepository<T> where T : class, new()
    {
        long Insert(T entity);
    }
}
