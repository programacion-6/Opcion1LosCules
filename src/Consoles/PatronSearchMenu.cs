namespace Opcion1LosCules;
public class PatronSearchMenu
{
    private readonly PatronsManager _patronManager;
        
    public PatronSearchMenu( PatronsManager patronManager)
    {
        _patronManager = patronManager;
    }

    public void DisplaySearchMenu()
    {
        Console.WriteLine("Select search criteria:");
        Console.WriteLine("1. Search by Name");
        Console.WriteLine("2. Search by Membership Number");
            
        var option = Console.ReadLine();
        Console.WriteLine("Enter search term:");
        var query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            Console.WriteLine("Search term cannot be empty.");
            return;
        }
            
        List<Patron> searchResults = new();
            
        switch (option)
            {
            case "1":
                searchResults = SearchByName(query);
                break;
            case "2":
                searchResults = SearchByMembershipNumber(query);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        DisplaySearchResults(searchResults);
    }

    public List<Patron> SearchByName(string name)
    {
        var strategy = new SearchByName();
        return strategy.Search(name, _patronManager.GetAllPatrons());
    }

    public List<Patron> SearchByMembershipNumber(string membershipNumber)
    {
        var strategy = new SearchByMembershipNumber();
        return strategy.Search(membershipNumber, _patronManager.GetAllPatrons());
    }

    private void DisplaySearchResults(List<Patron> patrons)
    {
        if (patrons.Any())
        {
            Console.WriteLine("Search results:");
            foreach (var patron in patrons)
            {
                Console.WriteLine($"Name: {patron.Name}, Membership Number: {patron.MembershipNumber}");
            }
        }
        else
        {
            Console.WriteLine("No results found.");
        }
    }
}


