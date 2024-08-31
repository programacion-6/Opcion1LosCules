using Spectre.Console;


namespace Opcion1LosCules
{
    public static class UIUtils
    {
        public static void PaginateTable(IPaginationStrategy strategy, Table table, List<string[]> rows, int pageSize = 5)
        {
            strategy.Paginate(table, rows, pageSize);
        }
    }
}