namespace Opcion1LosCules;
using Spectre.Console;
public class PatronSearchMenu
{
    private readonly PatronsManager _patronManager;
        
    public PatronSearchMenu( PatronsManager patronManager)
    {
        _patronManager = patronManager;
    }

    public void DisplaySearchMenu()
    {
        var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Select search criteria:[/]")
                    .AddChoices("Search by Name", "Search by Membership Number"));

        var query = AnsiConsole.Ask<string>("[green]Enter search term:[/]");


        if (string.IsNullOrWhiteSpace(query))
        {
            AnsiConsole.MarkupLine("[red]Search term cannot be empty.[/]");
            return;
        }
            
        List<Patron> searchResults = new();
            
        switch (option)
            {
            case "Search by Name":
                searchResults = SearchByName(query);
                break;
            case "Search by Membership Number":
                searchResults = SearchByMembershipNumber(query);
                break;
            default:
                AnsiConsole.MarkupLine("[red]Invalid option.[/]");
                break;
        }

        DisplaySearchResults(searchResults);
    }

    public List<Patron> SearchByName(string name)
    {
        var strategy = new SearchByName(name);
        return strategy.Search(_patronManager.Items);
    }

    public List<Patron> SearchByMembershipNumber(string membershipNumber)
    {
        var strategy = new SearchByMembershipNumber(int.Parse(membershipNumber));
        return strategy.Search(_patronManager.Items);
    }

    private void DisplaySearchResults(List<Patron> patrons)
    {
        if (patrons.Any())
        {
            var table = new Table();

                table.AddColumn("Name");
                table.AddColumn("Membership Number");
                table.AddColumn("Email");

                foreach (var patron in patrons)
                {
                    
                    table.AddRow(patron.Name, patron.MembershipNumber.ToString(),patron.ContactDetails);
                }
                AnsiConsole.Write(table);
        }
        else
        {
           AnsiConsole.MarkupLine("[red]No results found.[/]");
        }
    }
}