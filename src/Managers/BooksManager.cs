using Spectre.Console;

namespace Opcion1LosCules;
public class BooksManager : IEntityRepository<Book>
{
    private readonly BookValidator _bookValidator;
    private readonly IDatabaseContext _database;

    public BooksManager(IDatabaseContext databaseContext)
    {
        _bookValidator = new BookValidator();
        _database = databaseContext;
    }

    public async Task AddEntity(Book book)
    {
        _bookValidator.Validate(book);
        if(await _database.Add(book) != 200)
        {
            AnsiConsole.WriteLine("Error to add the book.");
        }
    }

    public async Task<IEnumerable<IEntity>> GetAll()
    {
        return await _database.GetAll<Book>();
    }

    public async Task<IEntity> GetById(string id)
    {
        return await _database.GetById<Book>(id);
    }

    public async Task RemoveEntity(string id)
    {
        await _database.Delete(id);
    }

    public async Task UpdateEntity(string id, Book book)
    {
        if(await _database.Update(id, book) != 200)
        {
            AnsiConsole.WriteLine("Error to update the Book.");
        }
    }
}
