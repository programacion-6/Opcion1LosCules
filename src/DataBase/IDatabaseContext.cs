public interface IDatabaseContext<T>
{
    public int Add(T entity);
    public int Update(string id, IEntity entity);
    public int Delete(T entity);
    public IEntity GetById(string id);
}