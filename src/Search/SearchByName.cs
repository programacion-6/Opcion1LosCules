namespace Opcion1LosCules;

public class SearchByName : ISearchStrategy<Patron>
{
    public string Name;

    public SearchByName(string name)
    {
        Name = name;
    }

    public List<Patron> Search(List<Patron> patrons)
    {
        return patrons
            .Where(patron => patron.Name.Contains(Name, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
}
