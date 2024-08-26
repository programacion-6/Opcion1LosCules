using Spectre.Console;

namespace Opcion1LosCules
{
    public static class UIUtils
    {
        public static void PaginateTable(Table table, List<string[]> rows, int pageSize = 5)
        {
            int pageIndex = 0;
            int totalPages = (int)Math.Ceiling((double)rows.Count / pageSize);

            while (true)
            {
                var currentRows = rows.Skip(pageIndex * pageSize).Take(pageSize);

                table.Rows.Clear();
                foreach (var row in currentRows)
                {
                    table.AddRow(row);
                }

                AnsiConsole.Clear();
                AnsiConsole.Write(table);

                var choices = new List<string>();
                if (pageIndex > 0) choices.Add("Previous");
                if (pageIndex < totalPages - 1) choices.Add("Next");
                choices.Add("Exit");

                var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[green]Choose an option:[/]")
                        .AddChoices(choices));

                switch (option)
                {
                    case "Previous":
                        pageIndex--;
                        break;
                    case "Next":
                        pageIndex++;
                        break;
                    case "Exit":
                        return;
                }
            }
        }
    }
}