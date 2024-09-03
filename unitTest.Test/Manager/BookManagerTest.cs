using Moq;
namespace Opcion1LosCules.Tests
{
    public class BooksManagerTests
    {
        private readonly BooksManager _booksManager;

        public BooksManagerTests()
        {
            _booksManager = new BooksManager(new Database());
        }
        [Fact]
        public async void RemoveBook_ShouldDeleteBookFromCollection()
        {
            var book = new Book("Batman 2", "George Orwell", "45825", "Dystopian", 1949);
            await _booksManager.AddEntity(book);

            await _booksManager.RemoveEntity(book.Id.ToString());

            Assert.DoesNotContain(book, await _booksManager.GetAll());
        }

        [Fact]
        public async void GetAllBooks_ShouldReturnAllAddedBooks()
        {
            var book1 = new Book("Superman 4", "George Orwell", "45825", "Dystopian", 1949);
            var book2 = new Book("Brave New World", "Aldous Huxley", "45826", "Science Fiction", 1932);

            await _booksManager.AddEntity(book1);
            await _booksManager.AddEntity(book2);

            var allBooks = await _booksManager.GetAll();

            Assert.Equal(2, allBooks.Count());
            Assert.Contains(book1, allBooks);
            Assert.Contains(book2, allBooks);
        }   
    }
}
