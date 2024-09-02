namespace Opcion1LosCules;

public class SearchByTitle : ISearchStrategy<Book>
{
    public string Title;

    public SearchByTitle(string title)
    {
        Title = title;
    }

    public List<Book> Search(List<Book> books)
    {
        return books
            .Where(book => book.Title.Contains(Title, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
