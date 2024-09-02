using Moq;
namespace Opcion1LosCules.Tests
{
    public class BorrowBookTests
    {
        private readonly IDatabaseContext _database;
        private readonly BorrowBook _borrowBook;

        public BorrowBookTests()
        {
            _database = new Database();
            _borrowBook = new BorrowBook(_database);
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