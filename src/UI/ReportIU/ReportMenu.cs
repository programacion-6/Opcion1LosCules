using Spectre.Console;
namespace Opcion1LosCules
{
    public class ReportMenu
    {
        private readonly BooksManager _booksManager;
        private readonly PatronsManager _patronsManager;

        public ReportMenu(BooksManager booksManager, PatronsManager patronsManager)
        {
            _booksManager = booksManager;
            _patronsManager = patronsManager;
        }

        public void DisplayReportMenu()
        {
            var option = AnsiConsole.Prompt(
                     new SelectionPrompt<string>()
                         .Title("[yellow]Report Menu:[/]")
                         .AddChoices(
                             "Show Borrowing History Report for a Patron",
                             "Show Currently Borrowed Books Report",
                             "Show Overdue Books Report",
                             "Exit"));

            switch (option)
            {
                case "Show Borrowing History Report for a Patron":
                    ShowBorrowPatronHistory();
                    break;
                case "Show Currently Borrowed Books Report":
                    ShowCurrentBorrowedBooksReport();
                    break;
                case "Show Overdue Books Report":
                    ShowOverdueBooksReport();
                    break;
                case "Exit":
                    return;
                default:
                    AnsiConsole.MarkupLine("[red]Invalid option. Please try again.[/]");
                    break;
            }
        }

        private void DisplayReport(string title, List<object> reportItems)
        {
            AnsiConsole.WriteLine($"{title}");

            if (reportItems.Any())
            {
                var table = new Table();
                table.AddColumn(new TableColumn("[yellow]Title[/]").Centered());
                table.AddColumn(new TableColumn("[yellow]Author[/]").Centered());
                table.AddColumn(new TableColumn("[yellow]ISBN[/]").Centered());
                table.AddColumn(new TableColumn("[yellow]Genre[/]").Centered());
                table.AddColumn(new TableColumn("[yellow]Borrowed On[/]").Centered());
                table.AddColumn(new TableColumn("[yellow]Due Date[/]").Centered());

                var rows = reportItems.Select(item => new string[]
                {
                    GetPropertyValue(item, "Title"),
                    GetPropertyValue(item, "Author"),
                    GetPropertyValue(item, "ISBN"),
                    GetPropertyValue(item, "Genre"),
                    GetPropertyValue(item, "BorrowedOn"),
                    GetPropertyValue(item, "DueDate")
                }).ToList();

                UIUtils.PaginateTable(new StandardPagination(), table, rows);
            }
            else
            {
                AnsiConsole.MarkupLine("[red]No data available.[/]");
            }
            AnsiConsole.WriteLine();

        }

        private string GetPropertyValue(object obj, string propertyName)
        {
            var property = obj.GetType().GetProperty(propertyName);
            if (property != null)
            {
                var value = property.GetValue(obj);
                return value?.ToString() ?? "";
            }
            return "";
        }

        private bool HasProperty(dynamic obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        public async void ShowBorrowPatronHistory()
        {
            var existingPatrons = await _patronsManager.GetAllPatrons();

            if (!existingPatrons.Any())
            {
                AnsiConsole.MarkupLine("[red]No patrons found.[/]");
                return;
            }

            var selectedPatron = UIUtils.DisplaySelectableListResult(existingPatrons);

            if (selectedPatron == null)
            {
                AnsiConsole.MarkupLine("[red]No patron selected.[/]");
                return;
            }

            var reportContext = new ReportContext(new BorrowingHistoryReport(selectedPatron));
            var report = await reportContext.GenerateReport(_patronsManager);
            DisplayReport($"Borrowing History Report for {selectedPatron.Name}", report);
        }

        public async void ShowCurrentBorrowedBooksReport()
        {
            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());
            var report = await reportContext.GenerateReport(_patronsManager);
            DisplayReport("Currently Borrowed Books Report", report);
        }

        public async void ShowOverdueBooksReport()
        {
            var reportContext = new ReportContext(new OverdueBooksReport());
            var report = await reportContext.GenerateReport(_patronsManager);
            DisplayReport("Overdue Books Report", report);
        }
    }
}
