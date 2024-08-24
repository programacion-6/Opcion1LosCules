using Spectre.Console;
namespace Opcion1LosCules
{
    public class BookMenu 
    {
        private BooksManagementMenu _bookManagement;
        private Library _library;
        
        public BookMenu(Library library) 
        {
            _library = library;
            _bookManagement = new BooksManagementMenu(_library);
        }

        public void ShowBookMenu()
        {
            while (true)
            {
                 var option = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                        .Title("[yellow]Book Menu[/]")
                        .AddChoices("Add Book", "Update Book", "Remove Book", "Exit"));

                switch (option)
                {
                    case "Add Book":
                        _bookManagement.AddBook();
                        break;
                    case "Update Book":
                        _bookManagement.UpdateBook();
                        break;
                    case "Remove Book":
                        _bookManagement.RemoveBook();
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
}
