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
            Console.WriteLine("Report Menu:");
            Console.WriteLine("1. Show Borrowing History Report for a Patron");
            Console.WriteLine("2. Show Currently Borrowed Books Report");
            Console.WriteLine("3. Show Overdue Books Report");
            Console.WriteLine("0. Exit");
            Console.Write("Select an option: ");
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    ShowBorrowPatronHistory();
                    break;
                case "2":
                    ShowCurrentBorrowedBooksReport();
                    break;
                case "3":
                    ShowOverdueBooksReport();
                    break;
                case "0":
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }

        private void DisplayReport(string title, List<object> reportItems)
        {
            Console.WriteLine($"\n{title}");
            Console.WriteLine(new string('-', title.Length));
            
            if (reportItems.Any())
            {
                foreach (var item in reportItems)
                {
                    dynamic reportItem = item;

                    if (HasProperty(reportItem, "Title")) 
                        Console.WriteLine($"Title     : {reportItem.Title}");
                    if (HasProperty(reportItem, "Author")) 
                        Console.WriteLine($"Author    : {reportItem.Author}");
                    if (HasProperty(reportItem, "ISBN")) 
                        Console.WriteLine($"ISBN      : {reportItem.ISBN}");
                    if (HasProperty(reportItem, "Genre")) 
                        Console.WriteLine($"Genre     : {reportItem.Genre}");
                    if (HasProperty(reportItem, "BorrowedOn")) 
                        Console.WriteLine($"BorrowedOn: {reportItem.BorrowedOn}");
                    if (HasProperty(reportItem, "DueDate")) 
                        Console.WriteLine($"DueDate   : {reportItem.DueDate}");
                    
                    Console.WriteLine(); 
                }
            }
            else
            {
                Console.WriteLine("No data available.");
            }
            Console.WriteLine();
        }

        private bool HasProperty(dynamic obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }

        public void ShowBorrowPatronHistory()
        {
            Console.Write("Enter Patron Membership Number: ");
            if (int.TryParse(Console.ReadLine(), out int membershipNumber))
            {
                var patron = _patronsManager.GetAllPatrons()
                                            .FirstOrDefault(p => p.MembershipNumber == membershipNumber);
                if (patron != null)
                {
                    var reportContext = new ReportContext(new BorrowingHistoryReport(patron));
                    var report = reportContext.GenerateReport(_booksManager, _patronsManager);
                    DisplayReport($"Borrowing History Report for {patron.Name}", report);
                }
                else
                {
                    Console.WriteLine("Patron not found.");
                }
            }
            else
            {
                Console.WriteLine("Invalid Membership Number.");
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
