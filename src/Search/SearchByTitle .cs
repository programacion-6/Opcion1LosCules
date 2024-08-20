namespace Opcion1LosCules;
public class SearchByTitle : IBookSearchStrategy
{
    public List<Book> Search(string title, List<Book> books)
    {
        return books.Where(book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}