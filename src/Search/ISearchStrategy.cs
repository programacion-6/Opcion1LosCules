namespace Opcion1LosCules;

public interface ISearchStrategy<T>
{
    List<T> Search(List<T> dataList);
}
