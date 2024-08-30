namespace Opcion1LosCules;
public class StandardPagination : IPaginationStrategy
{
    public void Paginate(Table table, List<string[]> rows, int pageSize)
    {
        int pageIndex = 0;
        int totalPages = (int)Math.Ceiling((double)rows.Count / pageSize);

        while (true)
        {
            DisplayTable(table, rows.Skip(pageIndex * pageSize).Take(pageSize));

            var option = GetPaginationOption(pageIndex, totalPages);

            if (option == "Exit") break;

            UpdatePageIndex(option, ref pageIndex);
        }
    }

    private void DisplayTable(Table table, IEnumerable<string[]> currentRows)
    {
        table.Rows.Clear();
        foreach (var row in currentRows)
        {
            table.AddRow(row);
        }

        AnsiConsole.Clear();
        AnsiConsole.Write(table);
    }

    private string GetPaginationOption(int pageIndex, int totalPages)
    {
        var choices = new List<string>();
        if (pageIndex > 0) choices.Add("Previous");
        if (pageIndex < totalPages - 1) choices.Add("Next");
        choices.Add("Exit");

        return AnsiConsole.Prompt(
            new SelectionPrompt<string>()
                .Title("[green]Choose an option:[/]")
                .AddChoices(choices));
    }

    private void UpdatePageIndex(string option, ref int pageIndex)
    {
        switch (option)
        {
            case "Previous":
                pageIndex--;
                break;
            case "Next":
                pageIndex++;
                break;
        }
    }
}