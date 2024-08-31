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

                UIUtils.PaginateTable(new StandardPagination() ,table, rows);
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
                return value != null ? value.ToString() : "";
            }
            return "";
        }

        private bool HasProperty(dynamic obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        public void ShowBorrowPatronHistory()
        {
            AnsiConsole.Write("Enter Patron Membership Number: ");
            if (int.TryParse(Console.ReadLine(), out int membershipNumber))
            {
                var patron = _patronsManager.Items
                                            .FirstOrDefault(p => p.MembershipNumber == membershipNumber);
                if (patron != null)
                {
                    var reportContext = new ReportContext(new BorrowingHistoryReport(patron));
                    var report = reportContext.GenerateReport(_booksManager, _patronsManager);
                    DisplayReport($"Borrowing History Report for {patron.Name}", report);
                }
                else
                {
                    AnsiConsole.WriteLine("Patron not found.");
                }
            }
            else
            {
                AnsiConsole.WriteLine("Invalid Membership Number.");
            }
        }

        public void ShowCurrentBorrowedBooksReport()
        {
            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());
            var report = reportContext.GenerateReport(_booksManager, _patronsManager);
            DisplayReport("Currently Borrowed Books Report", report);
        }

        public void ShowOverdueBooksReport()
        {
            var reportContext = new ReportContext(new OverdueBooksReport());
            var report = reportContext.GenerateReport(_booksManager, _patronsManager);
            DisplayReport("Overdue Books Report", report);
        }
    }
}
