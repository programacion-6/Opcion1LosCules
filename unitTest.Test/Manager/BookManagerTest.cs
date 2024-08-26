using Moq;
namespace Opcion1LosCules.Tests
{
    public class BooksManagerTests
    {
        private readonly BooksManager _booksManager;
        private readonly Mock<IStorage<Book>> _mockBookStorage;

        public BooksManagerTests()
        {
            _mockBookStorage = new Mock<IStorage<Book>>();
            _mockBookStorage.Setup(x => x.Load()).Returns(new List<Book>());
            _booksManager = new BooksManager(_mockBookStorage.Object);
        }

        [Fact]
        public void AddBook_ShouldAddValidBook()
        {
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            
            _booksManager.AddBook(book);

            Assert.Contains(book, _booksManager.GetAllBooks());
        }

        [Fact]
        public void AddBook_ShouldNotAddDuplicateBook()
        {
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            
            _booksManager.AddBook(book);
            _booksManager.AddBook(book);  
            Assert.Single(_booksManager.GetAllBooks());
        }

        [Fact]
        public void UpdateBook_ShouldModifyExistingBook()
        {
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45892", "Fiction", 1951);
            var updatedBook = new Book("The Catcher in the Rye", "Salinger", "445842", "Literature", 1951);
            _booksManager.AddBook(book);

            _booksManager.UpdateBook(updatedBook);

            var existingBook = _booksManager.GetAllBooks().Find(b => b.Title == "The Catcher in the Rye");

            Assert.Equal("Literature", existingBook.Genre);
            Assert.Equal("Salinger", existingBook.Author);
            Assert.Equal("445842", existingBook.ISBN);
            Assert.Equal(1951, existingBook.PublicationYear);

            Assert.Single(_booksManager.GetAllBooks());
        }


        [Fact]
        public void RemoveBook_ShouldDeleteBookFromCollection()
        {
            var book = new Book("1984", "George Orwell", "45825", "Dystopian", 1949);
            _booksManager.AddBook(book);

            _booksManager.RemoveBook(book);

            Assert.DoesNotContain(book, _booksManager.GetAllBooks());
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllAddedBooks()
        {
            var book1 = new Book("1984", "George Orwell", "45825", "Dystopian", 1949);
            var book2 = new Book("Brave New World", "Aldous Huxley", "45826", "Science Fiction", 1932);

            _booksManager.AddBook(book1);
            _booksManager.AddBook(book2);

            var allBooks = _booksManager.GetAllBooks();

            Assert.Equal(2, allBooks.Count);
            Assert.Contains(book1, allBooks);
            Assert.Contains(book2, allBooks);
        }   
    }
}
