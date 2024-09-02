namespace Opcion1LosCules;

public class SearchByISBN : ISearchStrategy<Book>
{
    public string ISBN;

    public SearchByISBN(string isbn)
    {
        ISBN = isbn;
    }

    public List<Book> Search(List<Book> books)
    {
        return books
            .Where(book => book.ISBN.Equals(ISBN, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
