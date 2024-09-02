namespace Opcion1LosCules.Tests
{  
    public class SearchByAuthorTests
    {
        [Fact]
        public void Search_ValidAuthor_ReturnsMatchingBooks()
        {
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001),
                new Book("Title2", "Author2", "00002", "Genre2", 2002),
                new Book("Title3", "Author1", "00003", "Genre3", 2003)
            };

            string query = "Author1";
            var searchStrategy = new SearchByAuthor(query);

            var result = searchStrategy.Search(books);

            Assert.Equal(2, result.Count);
            Assert.Contains(result, book => book.Title == "Title1");
            Assert.Contains(result, book => book.Title == "Title3");
        }

        [Fact]
        public void Search_InvalidAuthor_ReturnsEmptyList()
        {
            // Arrange
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001)
            };

            string query = "NonExistingAuthor";
            var searchStrategy = new SearchByAuthor(query);

            var result = searchStrategy.Search(books);

            Assert.Empty(result);
        }

        [Fact]
        public void Search_EmptyAuthor_ReturnsBooks()
        {
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001)
            };

            string query = string.Empty;
            var searchStrategy = new SearchByAuthor(query);

            var result = searchStrategy.Search(books);

            
            Assert.Single(result);
            Assert.Equal("Title1", result[0].Title);
        }

         [Fact]
        public void Search_EmptyBookList_ReturnsEmptyList()
        {
            var books = new List<Book>();
            string query = "Author1";
            var searchStrategy = new SearchByAuthor(query);

            var result = searchStrategy.Search(books);

            Assert.Empty(result);
        }
    }
}