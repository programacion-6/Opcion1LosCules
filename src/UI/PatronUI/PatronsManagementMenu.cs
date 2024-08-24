using Spectre.Console;
namespace Opcion1LosCules
{
    public class PatronsManagementMenu
    {
        private Library _library;
        private IPatronSearchStrategy _patronSearchStrategy;

        public PatronsManagementMenu(Library library) 
        {
            _library = library;
        }

        public void AddPatron()
        {
           var name = AnsiConsole.Ask<string>("[green]Enter patron name:[/]");
           int membershipNumber = AnsiConsole.Ask<int>("[green]Enter patron membership number:[/]");

           var contactDetails = AnsiConsole.Ask<string>("[green]Enter patron contact details (email):[/]");
            
           var patron = new Patron(name, membershipNumber, contactDetails);
           _library.patronsManager().AddPatron(patron);
           AnsiConsole.MarkupLine("[green]Patron added successfully.[/]");
        }

        public void UpdatePatron()
        {
            int membershipNumber = AnsiConsole.Ask<int>("[green]Enter patron membership number:[/]");

            var existingPatron = _library.patronsManager().GetAllPatrons()
                .FirstOrDefault(p => p.MembershipNumber == membershipNumber);

            if (existingPatron == null)
            {
                AnsiConsole.MarkupLine("[red]No patron found with that membership number. Please try again.[/]");
                return;
            }

            var name = AnsiConsole.Ask<string>("[green]Enter new patron name:[/]");
            var contactDetails = AnsiConsole.Ask<string>("[green]Enter new contact details (email):[/]");

            var updatedPatron = new Patron(name, membershipNumber, contactDetails);
            _library.patronsManager().UpdatePatron(updatedPatron);
            AnsiConsole.MarkupLine("[green]Patron updated successfully.[/]");
        }



        public void RemovePatron()
        {
             int membershipNumber = AnsiConsole.Ask<int>("[green]Enter patron membership number:[/]");

             var patron = _library.patronsManager().GetAllPatrons()
                .FirstOrDefault(p => p.MembershipNumber == membershipNumber);

            if (patron != null)
            {
                _library.patronsManager().RemovePatron(patron);
                AnsiConsole.MarkupLine("[green]Patron removed successfully.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Patron not found.[/]");
            }
        }
    }
}
