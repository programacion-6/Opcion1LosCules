namespace Opcion1LosCules.Pagination;
public interface IPaginationStrategy
{
    void Paginate(Table table, List<string[]> rows, int pageSize);
}