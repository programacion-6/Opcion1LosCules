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

            string query = "Title";
            var searchStrategy = new SearchByTitle(query);

            var result = searchStrategy.Search(books);

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

            string query = "NonExistingTitle";
            var searchStrategy = new SearchByTitle(query);

            var result = searchStrategy.Search(books);

            Assert.Empty(result);
        }

        [Fact]
        public void Search_EmptyTitle_ReturnsBooks()
        {
            var books = new List<Book>
            {
                new Book("Title1", "Author1", "00001", "Genre1", 2001)
            };

            string query = string.Empty;
            var searchStrategy = new SearchByTitle(query);

            var result = searchStrategy.Search(books);

            Assert.Single(result);
            Assert.Equal("Title1", result[0].Title);
        }

        [Fact]
        public void Search_EmptyBookList_ReturnsEmptyList()
        {
            var books = new List<Book>();
            string query = "Title";
            var searchStrategy = new SearchByTitle(query);

            var result = searchStrategy.Search(books);

            Assert.Empty(result);
        }   
    }
}