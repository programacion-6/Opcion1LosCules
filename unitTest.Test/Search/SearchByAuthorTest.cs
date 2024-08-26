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

            var searchStrategy = new SearchByAuthor();
            string query = "Author1";

            var result = searchStrategy.Search(query, books);

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

            var searchStrategy = new SearchByAuthor();
            string query = "NonExistingAuthor";

            var result = searchStrategy.Search(query, books);

            Assert.Empty(result);
        }

        [Fact]
        public void Search_EmptyAuthor_ReturnsBooks()
        {
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001)
            };

            var searchStrategy = new SearchByAuthor();
            string query = string.Empty;

            var result = searchStrategy.Search(query, books);

            
            Assert.Single(result);
            Assert.Equal("Title1", result[0].Title);
        }

         [Fact]
        public void Search_EmptyBookList_ReturnsEmptyList()
        {
            var books = new List<Book>();
            var searchStrategy = new SearchByAuthor();
            string query = "Author1";

            var result = searchStrategy.Search(query, books);

            Assert.Empty(result);
        }
    }
}