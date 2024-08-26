namespace Opcion1LosCules.Tests
{ 
    public class SearchByTitleTests
    {
        [Fact]
        public void Search_ValidTitle_ReturnsMatchingBooks()
        {
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001),
                new Book("AnotherTitle", "Author2", "00002", "Genre2", 2002),
                new Book("Title2", "Author3", "0003", "Genre3", 2003)
            };

            var searchStrategy = new SearchByTitle();
            string query = "Title";

            var result = searchStrategy.Search(query, books);

            Assert.Equal(3, result.Count);
            Assert.Contains(result, book => book.Title == "Title1");
            Assert.Contains(result, book => book.Title == "Title2");
        }

        [Fact]
        public void Search_InvalidTitle_ReturnsEmptyList()
        {
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001)
            };

            var searchStrategy = new SearchByTitle();
            string query = "NonExistingTitle";

            var result = searchStrategy.Search(query, books);

            Assert.Empty(result);
        }

        [Fact]
        public void Search_EmptyTitle_ReturnsBooks()
        {
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001)
            };

            var searchStrategy = new SearchByTitle();
            string query = string.Empty;

            var result = searchStrategy.Search(query, books);

            Assert.Single(result);
            Assert.Equal("Title1", result[0].Title);
        }

        [Fact]
        public void Search_EmptyBookList_ReturnsEmptyList()
        {
            var books = new List<Book>();
            var searchStrategy = new SearchByTitle();
            string query = "Title";

            var result = searchStrategy.Search(query, books);

            Assert.Empty(result);
        }   
    }
}