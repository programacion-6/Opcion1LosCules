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
            Console.WriteLine("0. Back to Main Menu");
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

                    Console.WriteLine("Borrowing History Report:");
                    foreach (var item in report)
                    {
                        Console.WriteLine(item);
                    }
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

            Console.WriteLine("Currently Borrowed Books Report:");
            foreach (var item in report)
            {
                Console.WriteLine(item);
            }
        }

        public void ShowOverdueBooksReport()
        {
            var reportContext = new ReportContext(new OverdueBooksReport());
            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Console.WriteLine("Overdue Books Report:");
            foreach (var item in report)
            {
                Console.WriteLine(item);
            }
        }
    }
}
