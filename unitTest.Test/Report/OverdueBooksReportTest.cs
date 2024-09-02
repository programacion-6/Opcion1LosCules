using Moq;
namespace Opcion1LosCules.Tests
{
    public class OverdueBooksReportTests
    {
        private readonly BooksManager _booksManager;
        private readonly PatronsManager _patronsManager;
        private readonly BorrowBook _borrowBook;
        private readonly IDatabaseContext _database;

        public OverdueBooksReportTests()
        {
            _database = new Database();
            _booksManager = new BooksManager(_database);
            _patronsManager = new PatronsManager(_database);
            _borrowBook = new BorrowBook(_database);

        }
        
       [Fact]
        public async void GenerateReport_ShouldReturnCorrectReport_WhenBooksAreOverdue()
        {        
            var overdueBook = new Book("El Quijote", "Miguel de Cervantes", "1234567890", "Novela", 1605);
            var nonOverdueBook = new Book("Cien Años de Soledad", "Gabriel García Márquez", "0987654321", "Realismo Mágico", 1967);
            var patron = new Patron("Juan Pérez", 1, "juan.perez@example.com");

            await _booksManager.AddBook(overdueBook);
            await _booksManager.AddBook(nonOverdueBook);
            await _patronsManager.AddPatron(patron);

            _borrowBook.SetBook(overdueBook);
            _borrowBook.SetPatron(patron);
            _borrowBook.SetDate(DateTime.Now.AddDays(-16)); 
            _borrowBook.Execute();
            overdueBook.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-16)); 
            patron.BorrowedBooks.Add(overdueBook);
            IReportStrategy overdueBooksReportStrategy = new OverdueBooksReport();
            var reportContext = new ReportContext(overdueBooksReportStrategy);

            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.NotNull(report); 
            Assert.Single(report); 
        }

        [Fact]
        public async void GenerateReport_ShouldReturnEmptyReport_WhenNoBooksAreOverdue()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");
            var book1 = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            var book2 = new Book("To Kill a Mockingbird", "Harper Lee", "67890", "Fiction", 1960);
            book1.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-5)); 
            book2.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-10)); 
            patron.BorrowedBooks.Add(book1);
            patron.BorrowedBooks.Add(book2);

            await _patronsManager.AddPatron(patron);

            var reportContext = new ReportContext(new OverdueBooksReport());

            var report = await reportContext.GenerateReport(_patronsManager);

            Assert.Empty(report); 
        }
    
    }

}