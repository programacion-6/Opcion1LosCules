using Opcion1LosCules;

public interface IEntityRepository<T>
{
    Task AddEntity(T entity);
    Task UpdateEntity(string id, T entity);
    Task RemoveEntity(string id);
    Task<T> GetById(string id);
    Task<IEnumerable<T>> GetAll();
}
