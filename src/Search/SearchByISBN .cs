namespace Opcion1LosCules;
public class SearchByISBN : IBookSearchStrategy
{
    public List<Book> Search(string ISBN, List<Book> books)
    {
        return books.Where(book => book.ISBN.Equals(ISBN, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}