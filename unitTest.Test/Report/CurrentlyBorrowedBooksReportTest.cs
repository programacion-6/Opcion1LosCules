using Moq;
namespace Opcion1LosCules.Tests
{
    public class CurrentlyBorrowedBooksReportTests
    {
        private readonly BooksManager _booksManager;
        private readonly PatronsManager _patronsManager;
        private readonly IDatabaseContext _database;

        public CurrentlyBorrowedBooksReportTests()
        {
            _database = new Database();
            _booksManager = new BooksManager(_database);
            _patronsManager = new PatronsManager(_database);
        }
        
        [Fact]
        public async void GenerateReport_ShouldReturnCorrectReport_WhenBooksAreCurrentlyBorrowed()
        {
            var patron = new Patron("Sandra", 55845, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            book.BorrowingInfo.SetDueDate(DateTime.Now.AddDays(7));

            patron.BorrowedBooks.Add(book);

            await _patronsManager.AddPatron(patron); 
            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());

            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.Single(report); 
            var reportEntry = report[0].ToString();
            Assert.Contains("The Catcher in the Rye", reportEntry);
            Assert.Contains("Sandra", reportEntry);
            Assert.Contains(book.BorrowingInfo.DueDate.Value.ToShortDateString(), reportEntry);
        }

        [Fact]
        public async void GenerateReport_ShouldReturnEmptyReport_WhenNoBooksAreCurrentlyBorrowed()
        {
            var patron = new Patron("Sandra", 45848, "sandra@example.com");

            _patronsManager.AddPatron(patron); 

            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());

            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.Empty(report);
        }

        [Fact]
        public async void GenerateReport_ShouldReturnEmptyReport_WhenAllBorrowedBooksAreReturned()
        {
            var patron = new Patron("Sandra katherine", 45847, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45827", "Fiction", 1951);
            book.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-10)); 
            patron.BorrowedBooks.Add(book);
            book.BorrowingInfo.MarkAsReturned(DateTime.Now);
            await _patronsManager.AddPatron(patron);
            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());

            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.Empty(report); 
        }


    }
}