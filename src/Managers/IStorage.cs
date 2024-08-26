namespace Opcion1LosCules;
public interface IStorage<T>
{
    void Save(List<T> items);
    List<T> Load();
}
