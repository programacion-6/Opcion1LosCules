using Spectre.Console;

namespace Opcion1LosCules
{
    public static class UIUtils
    {
        public static void PaginateTable(IPaginationStrategy strategy, Table table, List<string[]> rows, int pageSize = 5)
        {
            strategy.Paginate(table, rows, pageSize);
        }

        public static T DisplaySelectableListResult<T>(IEnumerable<T> choices)
            where T : notnull
        {
            var selectedChoice = AnsiConsole.Prompt(
                new SelectionPrompt<T>()
                    .Title("[yellow]Select an option[/]")
                    .PageSize(3)
                    .MoreChoicesText("[grey](Move up and down to reveal more options)[/]")
                    .AddChoices(choices)
            );

            return selectedChoice;
        }
    }
}
