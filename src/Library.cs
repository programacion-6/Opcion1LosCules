namespace Opcion1LosCules;

public class Library
{
    private readonly List<Book> _books;
    private readonly List<Patron> _patrons;
    private BooksManager _booksManager;
    private PatronsManager _patronsManager;

    public Library()
    {
        _books = new List<Book>();
        _patrons = new List<Patron>();
        _booksManager = new BooksManager();
        _patronsManager = new PatronsManager();
    }
}