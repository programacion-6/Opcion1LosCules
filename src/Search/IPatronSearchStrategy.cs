namespace Opcion1LosCules;
public interface IPatronSearchStrategy
{
    List<Patron> Search(string query, List<Patron> patrons);
}
