using Spectre.Console;

namespace Opcion1LosCules;
public class BooksManager : IEntityRepository<Book>
{
    private readonly Validator<Book> _validator;
    private readonly IDatabaseContext _database;

    public BooksManager(IDatabaseContext databaseContext)
    {
        _validator = new Validator<Book>(CreateBookValidations().ToList());
        _database = databaseContext;
    }

    public async Task AddEntity(Book book)
    {
        _validator.Validate(book);
        if(await _database.Add(book) != 200)
        {
            AnsiConsole.WriteLine("Error to add the book.");
        }
    }

    public async Task<IEnumerable<Book>> GetAll()
    {
        return await _database.GetAll<Book>();
    }

    public async Task<Book> GetById(string id)
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

    private static IEnumerable<IValidation<Book>> CreateBookValidations()
        {
            return new List<IValidation<Book>>
            {
                new TitleValidation(),
                new AuthorValidation(),
                new ISBNValidation(),
                new GenreValidation(),
                new PublicationYearValidation(),
                new AvailabilityValidation()
            };
        }
}
