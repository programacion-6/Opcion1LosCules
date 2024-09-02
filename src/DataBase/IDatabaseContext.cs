public interface IDatabaseContext
{
    Task<int> Add<T>(T entity) where T : class;
    Task<int> Update<T>(string id, T entity) where T : class;
    Task<int> Delete(string id);
    Task<T> GetById<T>(string id) where T : class;
    Task<IEnumerable<T>> GetAll<T>() where T : class;
}