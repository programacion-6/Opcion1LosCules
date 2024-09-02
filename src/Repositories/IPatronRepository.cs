using Opcion1LosCules;

public interface IPatronRepository
{
    Task AddPatron(Patron patron);
    Task UpdatePatron(string id, Patron patron);
    Task RemovePatron(string id);
    Task<Patron> GetPatronById(string id);
    Task<IEnumerable<Patron>> GetAllPatrons();
}