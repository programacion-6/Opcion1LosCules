
using Spectre.Console;

namespace Opcion1LosCules;
public class BooksManager : IBookRepository
{
    private readonly BookValidator _bookValidator;
    private readonly IDatabaseContext _database;

    public BooksManager(IDatabaseContext databaseContext)
    {
        _bookValidator = new BookValidator();
        _database = databaseContext;
    }

    public async Task AddBook(Book book)
    {
        _bookValidator.Validate(book);
        if(await _database.Add(book) != 200)
        {
            throw new ArgumentException("Error to add the book.");
        }
    }

    public Task<IEnumerable<Book>> GetAllBooks()
    {
        return _database.GetAll<Book>();
    }

    public Task<Book> GetBookById(string id)
    {
        return _database.GetById<Book>(id);
    }

    public async Task RemoveBook(string id)
    {
        await _database.Delete(id);
    }

    public async Task UpdateBook(string id, Book book)
    {
        if(await _database.Update<Book>(id, book) != 200)
        {
            throw new ArgumentException("Error to Update the Book.");
        }
    }
}
