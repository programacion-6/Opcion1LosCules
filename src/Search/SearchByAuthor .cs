namespace Opcion1LosCules;

public class SearchByAuthor : ISearchStrategy<Book>
{
    public string Author;

    public SearchByAuthor(string author)
    {
        Author = author;
    }

    public List<Book> Search(List<Book> dataList)
    {
        return dataList
            .Where(book => book.Author.Contains(Author, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
