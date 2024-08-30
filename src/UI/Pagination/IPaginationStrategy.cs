using Spectre.Console;

namespace Opcion1LosCules;
public interface IPaginationStrategy
{
    void Paginate(Table table, List<string[]> rows, int pageSize);
}