namespace Opcion1LosCules;
public class BooksManager
{
    private readonly List<Book> _books;
    private readonly BookValidator _bookValidator;

    public BooksManager()
    {
        _books = new List<Book>();
        _bookValidator = new BookValidator();
    }
    public void AddBook(Book book)
    {
        _bookValidator.Validate(book);
        if (!_books.Contains(book))
        {
            _books.Add(book);
        }
    }

    public void UpdateBook(Book book)
    {
        _bookValidator.Validate(book);
        var existingBook = _books.FirstOrDefault(b => b.Title == book.Title);
        
        if (existingBook != null)
        {
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.Genre = book.Genre;
            existingBook.PublicationYear = book.PublicationYear;
        }
    }

    public void RemoveBook(Book book)
    {
        if (_books.Contains(book))
        {
            _books.Remove(book);
        }
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }
}