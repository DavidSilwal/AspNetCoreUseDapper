namespace Repository
{
    public partial interface IRepository<T> where T : class, new()
    {
        long Insert(T entity);
        bool Delete(T entity);
        bool Update(T entity);
        T Get(object id);
    }
}
