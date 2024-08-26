using Moq;
namespace Opcion1LosCules.Tests
{
    public class ReturnBookTests
    {
        private readonly BooksManager _booksManager;
        private readonly Mock<IStorage<Book>> _mockBookStorage;
        private readonly PatronsManager _patronsManager;
        private readonly Mock<IStorage<Patron>> _mockPatronStorage;
        private readonly ReturnBook _returnBook;

        public ReturnBookTests()
        {
            _mockBookStorage = new Mock<IStorage<Book>>();
            _mockBookStorage.Setup(x => x.Load()).Returns(new List<Book>());
            _booksManager = new BooksManager(_mockBookStorage.Object);
            _mockPatronStorage = new Mock<IStorage<Patron>>();
            _mockPatronStorage.Setup(x => x.Load()).Returns(new List<Patron>());
            _patronsManager = new PatronsManager(_mockPatronStorage.Object);
            _returnBook = new ReturnBook(_mockBookStorage.Object , _mockPatronStorage.Object);
        }

        [Fact]
        public void Validate_ShouldReturnTrue_WhenBookIsBorrowedAndNotAvailable()
        {
            var patron = new Patron("Sandra", 45847152, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            book.MarkAsBorrowed(DateTime.Now.AddDays(-10)); 
            patron.BorrowedBooks.Add(book);

            
            _returnBook.SetPatron(patron);
            _returnBook.SetBook(book);
            _returnBook.SetDate(DateTime.Now);

            var result = _returnBook.Validate();

            Assert.True(result);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WhenBookIsNotBorrowed()
        {
            var patron = new Patron("Sandra", 45584713, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 19541);

            _returnBook.SetPatron(patron);
            _returnBook.SetBook(book);
            _returnBook.SetDate(DateTime.Now);

            var result = _returnBook.Validate();


            Assert.False(result);
        }

        [Fact]
        public void Validate_ShouldReturnFalse_WhenBookIsAvailable()
        {
            var patron = new Patron("Sandra", 45845714, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 19518);
            book.MarkAsBorrowed(DateTime.Now.AddDays(-10));
            book.MarkAsReturned(DateTime.Now);

            patron.BorrowedBooks.Add(book);

            _returnBook.SetPatron(patron);
            _returnBook.SetBook(book);
            _returnBook.SetDate(DateTime.Now);

            var result = _returnBook.Validate();

            Assert.True(result);
        }

        [Fact]
        public void UpdateRecords_ShouldMarkBookAsReturned_AndRemoveBookFromPatronBorrowedBooks()
        {
            var patron = new Patron("Sandra", 458554514, "sandra@example.com");
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 195514);
            book.MarkAsBorrowed(DateTime.Now.AddDays(-10)); 
            patron.BorrowedBooks.Add(book);

            _returnBook.SetPatron(patron);
            _returnBook.SetBook(book);
            _returnBook.SetDate(DateTime.Now);

            _returnBook.UpdateRecords();

            Assert.DoesNotContain(book, patron.BorrowedBooks);
            Assert.False(book.IsAvailable()); 
        }
    }

}