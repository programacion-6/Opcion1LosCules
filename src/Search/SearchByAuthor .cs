namespace Opcion1LosCules;
public class SearchByAuthor : IBookSearchStrategy
{
    public List<Book> Search(string author, List<Book> books)
    {
        return books.Where(book => book.Author.Contains(author, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}