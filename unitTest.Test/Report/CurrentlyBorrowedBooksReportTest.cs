using Moq;
namespace Opcion1LosCules.Tests
{
    public class CurrentlyBorrowedBooksReportTests
    {
        private readonly BooksManager _booksManager;
        private readonly Mock<IStorage<Book>> _mockBookStorage;
        private readonly PatronsManager _patronsManager;
        private readonly Mock<IStorage<Patron>> _mockPatronStorage;

        public CurrentlyBorrowedBooksReportTests()
        {
            _mockBookStorage = new Mock<IStorage<Book>>();
            _mockBookStorage.Setup(x => x.Load()).Returns(new List<Book>());
            _booksManager = new BooksManager(_mockBookStorage.Object);
            _mockPatronStorage = new Mock<IStorage<Patron>>();
            _mockPatronStorage.Setup(x => x.Load()).Returns(new List<Patron>());
            _patronsManager = new PatronsManager(_mockPatronStorage.Object);
        }

        [Fact]
        public void GenerateReport_ShouldReturnCorrectReport_WhenBooksAreCurrentlyBorrowed()
        {
            var patron = new Patron("Sandra", 55845, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            book.BorrowingInfo.SetDueDate(DateTime.Now.AddDays(7));

            patron.BorrowedBooks.Add(book);

            _patronsManager.AddItem(patron);
            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());

            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.Single(report);
            var reportEntry = report[0].ToString();
            Assert.Contains("The Catcher in the Rye", reportEntry);
            Assert.Contains("Sandra", reportEntry);
            if (book.BorrowingInfo.DueDate.HasValue)
            {
                Assert.Contains(book.BorrowingInfo.DueDate.Value.ToShortDateString(), reportEntry);
            }
        }

        [Fact]
        public void GenerateReport_ShouldReturnEmptyReport_WhenNoBooksAreCurrentlyBorrowed()
        {
            var patron = new Patron("Sandra", 45848, "sandra@example.com");

            _patronsManager.AddItem(patron);

            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());

            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.Empty(report);
        }

        [Fact]
        public void GenerateReport_ShouldReturnEmptyReport_WhenAllBorrowedBooksAreReturned()
        {
            var patron = new Patron("Sandra katherine", 45847, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45827", "Fiction", 1951);
            book.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-10));
            patron.BorrowedBooks.Add(book);
            book.BorrowingInfo.MarkAsReturned(DateTime.Now);
            _patronsManager.AddItem(patron);
            var reportContext = new ReportContext(new CurrentlyBorrowedBooksReport());

            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.Empty(report);
        }


    }
}