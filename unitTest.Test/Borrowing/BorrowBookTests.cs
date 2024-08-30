using Moq;
namespace Opcion1LosCules.Tests
{
    public class BorrowBookTests
    {
        private readonly BooksManager _booksManager;
        private readonly Mock<IStorage<Book>> _mockBookStorage;
        private readonly PatronsManager _patronsManager;
        private readonly Mock<IStorage<Patron>> _mockPatronStorage;
        private readonly BorrowBook _borrowBook;

        public BorrowBookTests()
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
        public void Validate_ShouldReturnTrue_WhenBookIsAvailableAndNotAlreadyBorrowed()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");        
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            
            _borrowBook.SetPatron(patron);
            _borrowBook.SetBook(book);
            _borrowBook.SetDate(DateTime.Now);

            var result = _borrowBook.Validate();

            Assert.True(result);
        }

        [Fact]
        public void UpdateRecords_ShouldMarkBookAsBorrowed_AndAddBookToPatronBorrowedBooks()
        {
            var patron = new Patron("Sandra", 45845, "sandra@example.com");        
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            
            _borrowBook.SetPatron(patron);
            _borrowBook.SetBook(book);
            _borrowBook.SetDate(DateTime.Now);

            _borrowBook.UpdateRecords();

            Assert.Contains(book, patron.BorrowedBooks);
            Assert.False(book.BorrowingInfo.IsAvailable()); 
        }
        
    }
}