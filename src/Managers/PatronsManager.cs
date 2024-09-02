namespace Opcion1LosCules;

using System.Threading.Tasks;
using Spectre.Console;

public class PatronsManager : IPatronRepository
{
    private readonly PatronValidator _patronValidator;
    private readonly IDatabaseContext _database;


    public PatronsManager(IDatabaseContext databaseContext)
    {
        _patronValidator = new PatronValidator();
        _database = databaseContext;
    }

    public async Task AddPatron(Patron patron)
    {
        _patronValidator.Validate(patron);
        if(await _database.Add(patron) != 200)
        {
            AnsiConsole.WriteLine("Error to add the patron.");
        }
    }

    public Task<IEnumerable<Patron>> GetAllPatrons()
    {
        return _database.GetAll<Patron>();
    }

    public Task<Patron> GetPatronById(string id)
    {
        return _database.GetById<Patron>(id);
    }

    public async Task RemovePatron(string id)
    {
        if(await _database.Delete(id) != 200)
        {
            AnsiConsole.WriteLine("Error to Remove the patron.");
        }
    }

    public async Task UpdatePatron(string id, Patron patron)
    {
        if(await _database.Update(id, patron) != 200)
        {
            AnsiConsole.WriteLine("Error to Update the patron.");
        }
    }
}
