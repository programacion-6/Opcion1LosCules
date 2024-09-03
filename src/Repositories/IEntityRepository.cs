using Opcion1LosCules;

public interface IEntityRepository<T>
{
    Task AddEntity(T entity);
    Task UpdateEntity(string id, T entity);
    Task RemoveEntity(string id);
    Task<IEntity> GetById(string id);
    Task<IEnumerable<IEntity>> GetAll();
}
