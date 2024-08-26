namespace Opcion1LosCules;
public class BooksManager
{
    private readonly List<Book> _books;
    private readonly BookValidator _bookValidator;
    private readonly IStorage<Book> _bookStorage;

    public BooksManager(IStorage<Book> bookStorage)
    {
        _books = new List<Book>();
        _bookValidator = new BookValidator();
        _bookStorage = bookStorage;
        LoadBooksFromDB();
    }

    public void AddBook(Book book)
    {
        _bookValidator.Validate(book);
        if (!_books.Contains(book))
        {
            _books.Add(book);
            SaveBooksToDB();
        }
    }

    public void UpdateBook(Book book)
    {
        var existingBook = _books.FirstOrDefault(b => b.Title == book.Title);
        
        if (existingBook != null)
        {
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.Genre = book.Genre;
            existingBook.PublicationYear = book.PublicationYear;
            existingBook.DueDate = book.DueDate;
            existingBook.ReturnDate = book.ReturnDate;
            existingBook.IsBorrowed = book.IsBorrowed;
            SaveBooksToDB();
        }
    }

    public void RemoveBook(Book book)
    {
        if (_books.Contains(book))
        {
            _books.Remove(book);
            SaveBooksToDB();
        }
    }

    public List<Book> GetAllBooks()
    {
        return _books;
    }

    private void LoadBooksFromDB()
    {
        var booksFromJson = _bookStorage.Load();
        _books.AddRange(booksFromJson);
    }

    private void SaveBooksToDB()
    {
        _bookStorage.Save(_books);
    }
}
