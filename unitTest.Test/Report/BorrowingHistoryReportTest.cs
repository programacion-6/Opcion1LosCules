using Moq;
namespace Opcion1LosCules.Tests
{
    public class BorrowingHistoryReportTests
    {
        private readonly BooksManager _booksManager;
        private readonly PatronsManager _patronsManager;
        private readonly IDatabaseContext _database;

        public BorrowingHistoryReportTests()
        {
            _database = new Database();
            _booksManager = new BooksManager(_database);
            _patronsManager = new PatronsManager(_database);
        }
        
        [Fact]
        public async void GenerateReport_ShouldReturnCorrectReport_WhenPatronHasHistory()
        {
            var patron = new Patron("Sandra", 45877, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);

            patron.HistoryBorrowedBooks.Add(book);

            var reportContext = new ReportContext(new BorrowingHistoryReport(patron));
            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.Single(report);  
            var reportItem = report[0];

            Assert.Contains("The Catcher in the Rye", reportItem.ToString());
            Assert.Contains("J.D. Salinger", reportItem.ToString());
            Assert.Contains("45825", reportItem.ToString());
            Assert.Contains("Fiction", reportItem.ToString());
        }

        [Fact]
        public async void GenerateReport_ShouldReturnEmptyReport_WhenPatronHasNoHistory()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");

            var reportContext = new ReportContext(new BorrowingHistoryReport(patron));
            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.Empty(report);  
        }

        [Fact]
        public async void GenerateReport_ShouldReturnCorrectReport_WhenPatronHasMultipleBooksInHistory()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");
            var book1 = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            var book2 = new Book("1984", "George Orwell", "12345", "Dystopian", 1949);
            
            patron.HistoryBorrowedBooks.Add(book1);
            patron.HistoryBorrowedBooks.Add(book2);
                     
            var reportContext = new ReportContext(new BorrowingHistoryReport(patron));

            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.Equal(2, report.Count);  
            Assert.Contains(report, r => r.ToString().Contains("The Catcher in the Rye"));
            Assert.Contains(report, r => r.ToString().Contains("1984"));
        }
    }
}
