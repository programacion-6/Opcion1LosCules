using Spectre.Console;
namespace Opcion1LosCules;
public class PatronMenu 
{
    private PatronsManagementMenu _patronsManagement;
    private Library _library;
    
    public PatronMenu(Library library) 
    {
        _library = library;
        _patronsManagement = new PatronsManagementMenu(_library);
    }

    public void showPatronMenu()
    {
         while (true)
            {
                 var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Patron Menu[/]")
                        .AddChoices("Add Patron", "Update Patron", "Remove Patron", "List Patrons", "Exit"));

                switch (option)
                {
                    case "Add Patron":
                        _patronsManagement.AddPatron();
                        break;
                    case "Update Patron":
                        _patronsManagement.UpdatePatron();
                        break;
                    case "Remove Patron":
                        _patronsManagement.RemovePatron();
                        break;
                    case "List Patrons":
                        _patronsManagement.ListPatrons();
                        break;
                    case "Exit":
                        return;
                    default:
                        AnsiConsole.MarkupLine("[red]Invalid option. Please try again.[/]");
                        break;
                }
            }
    }
}