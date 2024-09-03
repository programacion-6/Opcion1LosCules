namespace Opcion1LosCules;

using System.Threading.Tasks;
using Spectre.Console;

public class PatronsManager : IEntityRepository<Patron>
{
    private readonly Validator<Patron> _validator;
    private readonly IDatabaseContext _database;


    public PatronsManager(IDatabaseContext databaseContext)
    {
        _validator = new Validator<Patron>(CreatePatronValidations().ToList());
        _database = databaseContext;
    }

    public async Task AddEntity(Patron patron)
    {
        _validator.Validate(patron);
        if(await _database.Add(patron) != 200)
        {
            AnsiConsole.WriteLine("Error to add the patron.");
        }
    }

    public async Task<IEnumerable<Patron>> GetAll()
    {
        return await _database.GetAll<Patron>();
    }

    public async Task<Patron> GetById(string id)
    {
        return await _database.GetById<Patron>(id);
    }

    public async Task RemoveEntity(string id)
    {
        if(await _database.Delete(id) != 200)
        {
            AnsiConsole.WriteLine("Error to Remove the patron.");
        }
    }

    public async Task UpdateEntity(string id, Patron patron)
    {
        if(await _database.Update(id, patron) != 200)
        {
            AnsiConsole.WriteLine("Error to Update the patron.");
        }
    }

    private static IEnumerable<IValidation<Patron>> CreatePatronValidations()
        {
            return new List<IValidation<Patron>>
            {
                new PatronNameValidation(),
                new MembershipNumberValidation(),
                new ContactDetailsValidation(),
                new NoOverdueBooksValidation()
            };
        }
}
