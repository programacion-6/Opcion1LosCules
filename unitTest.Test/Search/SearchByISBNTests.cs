namespace Opcion1LosCules.Tests
{    
    public class SearchByISBNTests
    {
        [Fact]
        public void Search_ValidISBN_ReturnsMatchingBook()
        {
        var books = new List<Book>
        {
            new Book("Title1", "Author1", "00001", "Genre1", 2001),
            new Book("Title2", "Author2", "00002", "Genre2", 2002)
        };

        string query = "00001";
        var searchStrategy = new SearchByISBN(query);

        var result = searchStrategy.Search(books);

        Assert.Single(result);
        Assert.Equal("Title1", result[0].Title);
    }

    [Fact]
    public void Search_InvalidISBN_ReturnsEmptyList()
    {
        var books = new List<Book>
        {
            new Book("Title1", "Author1", "00001", "Genre1", 2001)
        };

        string query = "00099";
        var searchStrategy = new SearchByISBN(query);

        var result = searchStrategy.Search(books);

        Assert.Empty(result);
    }

    [Fact]
    public void Search_EmptyISBN_ReturnsEmptyList()
    {
        var books = new List<Book>
        {
            new Book("Title1", "Author1", "00001", "Genre1", 2001)
        };

        string query = string.Empty;
        var searchStrategy = new SearchByISBN(query);

        var result = searchStrategy.Search(books);

        Assert.Empty(result);
    }
        [Fact]
        public void Search_EmptyBookList_ReturnsEmptyList()
        {
            var books = new List<Book>();
            string query = "00001";
            var searchStrategy = new SearchByISBN(query);

            var result = searchStrategy.Search(books);

            Assert.Empty(result);
        }   
    }
}