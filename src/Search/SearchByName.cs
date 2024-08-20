namespace Opcion1LosCules;
public class SearchByName : IPatronSearchStrategy
{
    public List<Patron> Search(string name, List<Patron> patrons)
    {
        return patrons.Where(patron => patron.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}