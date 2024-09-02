using Moq;
namespace Opcion1LosCules.Tests
{
    public class OverdueBooksReportTests
    {
        private readonly BooksManager _booksManager;
        private readonly Mock<IStorage<Book>> _mockBookStorage;
        private readonly PatronsManager _patronsManager;
        private readonly Mock<IStorage<Patron>> _mockPatronStorage;
        private readonly BorrowBook _borrowBook;

        public OverdueBooksReportTests()
        {
            _mockBookStorage = new Mock<IStorage<Book>>();
            _mockBookStorage.Setup(x => x.Load()).Returns(new List<Book>());
            _booksManager = new BooksManager(_mockBookStorage.Object);
            _mockPatronStorage = new Mock<IStorage<Patron>>();
            _mockPatronStorage.Setup(x => x.Load()).Returns(new List<Patron>());
            _patronsManager = new PatronsManager(_mockPatronStorage.Object);
            _borrowBook = new BorrowBook(_mockBookStorage.Object , _mockPatronStorage.Object);

        }
        
       [Fact]
        public void GenerateReport_ShouldReturnCorrectReport_WhenBooksAreOverdue()
        {        
            var overdueBook = new Book("El Quijote", "Miguel de Cervantes", "1234567890", "Novela", 1605);
            var nonOverdueBook = new Book("Cien Años de Soledad", "Gabriel García Márquez", "0987654321", "Realismo Mágico", 1967);
            var patron = new Patron("Juan Pérez", 1, "juan.perez@example.com");
            _booksManager.AddItem(overdueBook);
            _booksManager.AddItem(nonOverdueBook);
            _patronsManager.AddItem(patron);

            _borrowBook.SetBook(overdueBook);
            _borrowBook.SetPatron(patron);
            _borrowBook.SetDate(DateTime.Now.AddDays(-16)); 
            _borrowBook.Execute();
            overdueBook.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-16)); 
            patron.BorrowedBooks.Add(overdueBook);
            IReportStrategy overdueBooksReportStrategy = new OverdueBooksReport();
            var reportContext = new ReportContext(overdueBooksReportStrategy);

            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.NotNull(report); 
            Assert.Single(report); 
        }

        [Fact]
        public void GenerateReport_ShouldReturnEmptyReport_WhenNoBooksAreOverdue()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");
            var book1 = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            var book2 = new Book("To Kill a Mockingbird", "Harper Lee", "67890", "Fiction", 1960);
            book1.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-5)); 
            book2.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-10)); 
            patron.BorrowedBooks.Add(book1);
            patron.BorrowedBooks.Add(book2);
            _patronsManager.AddItem(patron);
            var reportContext = new ReportContext(new OverdueBooksReport());

            var report = reportContext.GenerateReport(_booksManager, _patronsManager);

            Assert.Empty(report); 
        }
    
    }

}