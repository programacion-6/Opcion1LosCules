using Moq;
namespace Opcion1LosCules.Tests
{
    public class BorrowingHistoryReportTests
    {
        private readonly BooksManager _booksManager;
        private readonly Mock<IStorage<Book>> _mockBookStorage;
        private readonly PatronsManager _patronsManager;
        private readonly Mock<IStorage<Patron>> _mockPatronStorage;

        public BorrowingHistoryReportTests()
        {
            _mockBookStorage = new Mock<IStorage<Book>>();
            _mockBookStorage.Setup(x => x.Load()).Returns(new List<Book>());
            _booksManager = new BooksManager(_mockBookStorage.Object);
            _mockPatronStorage = new Mock<IStorage<Patron>>();
            _mockPatronStorage.Setup(x => x.Load()).Returns(new List<Patron>());
            _patronsManager = new PatronsManager(_mockPatronStorage.Object);
        }

        [Fact]
        public void GenerateReport_ShouldReturnCorrectReport_WhenPatronHasHistory()
        {
            var patron = new Patron("Sandra", 45877, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);

            patron.HistoryBorrowedBooks.Add(book);

            var reportContext = new ReportContext(new BorrowingHistoryReport(patron));
            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.Single(report);
            var reportItem = report[0];

            Assert.Contains("The Catcher in the Rye", reportItem.ToString());
            Assert.Contains("J.D. Salinger", reportItem.ToString());
            Assert.Contains("45825", reportItem.ToString());
            Assert.Contains("Fiction", reportItem.ToString());
        }

        [Fact]
        public void GenerateReport_ShouldReturnEmptyReport_WhenPatronHasNoHistory()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");

            var reportContext = new ReportContext(new BorrowingHistoryReport(patron));
            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.Empty(report);
        }

        [Fact]
        public void GenerateReport_ShouldReturnCorrectReport_WhenPatronHasMultipleBooksInHistory()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");
            var book1 = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            var book2 = new Book("1984", "George Orwell", "12345", "Dystopian", 1949);

            patron.HistoryBorrowedBooks.Add(book1);
            patron.HistoryBorrowedBooks.Add(book2);

            var reportContext = new ReportContext(new BorrowingHistoryReport(patron));

            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.Equal(2, report.Count);
            Assert.Contains(report, r => (r?.ToString() ?? string.Empty).Contains("The Catcher in the Rye"));
            Assert.Contains(report, r => (r?.ToString() ?? string.Empty).Contains("1984"));
        }
    }
}
