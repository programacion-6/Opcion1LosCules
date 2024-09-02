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
        public void RemoveBook_ShouldDeleteBookFromCollection()
        {
            var book = new Book("1984", "George Orwell", "45825", "Dystopian", 1949);
            _booksManager.AddItem(book);

            _booksManager.RemoveItem(book);

            Assert.DoesNotContain(book, _booksManager.Items);
        }

        [Fact]
        public void GetAllBooks_ShouldReturnAllAddedBooks()
        {
            var book1 = new Book("1984", "George Orwell", "45825", "Dystopian", 1949);
            var book2 = new Book("Brave New World", "Aldous Huxley", "45826", "Science Fiction", 1932);

            _booksManager.AddItem(book1);
            _booksManager.AddItem(book2);

            var allBooks = _booksManager.Items;

            Assert.Equal(2, allBooks.Count);
            Assert.Contains(book1, allBooks);
            Assert.Contains(book2, allBooks);
        }   
    }
}
