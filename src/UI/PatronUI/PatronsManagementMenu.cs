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

        private string ValidateName(string prompt)
        {
            string value;
            do
            {
                value = AnsiConsole.Ask<string>(prompt);
                if (!string.IsNullOrEmpty(value) && value.All(char.IsLetter))
                {
                break; 
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Name must contain only alphabetic characters.[/]");
                }
            } while (true);

            return value;
        }

        private int ValidateMembershipNumber(string prompt)
        {
            int value;
            do
            {
                value = AnsiConsole.Ask<int>(prompt);
                if (value > 0)
                {
                    break;
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Membership number must be a positive number.[/]");
                }
            } while (true);

            return value;
        }

        public void AddPatron()
        {
            var name =  ValidateName("[green]Enter patron name:[/]");
            int membershipNumber = ValidateMembershipNumber("[green]Enter patron membership number:[/]");

            var contactDetails = AnsiConsole.Ask<string>("[green]Enter patron contact details (email):[/]");
            var patron = new Patron(name, membershipNumber, contactDetails);
            
            try
            {
                _library.patronsManager().AddPatron(patron);
                AnsiConsole.MarkupLine("[green]Patron added successfully.[/]");
            }
            catch (ValidationException ex)
            {
                AnsiConsole.MarkupLine($"[red]Failed to add patron: {ex.Message}[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]An unexpected error occurred: {ex.Message}[/]");
            }
        }

        public async void UpdatePatron()
        {
            string patronId = AnsiConsole.Ask<string>("[green]Enter patron membership Id:[/]");

            var existingPatron = _library.patronsManager().GetPatronById(patronId);

            if (existingPatron == null)
            {
                AnsiConsole.MarkupLine("[red]No patron found with that Id. Please try again.[/]");
                return;
            }

            var name = ValidateName("[green]Enter patron name:[/]");
            var membershipNumber = ValidateMembershipNumber("[green]Enter patron membership number:[/]");
            var contactDetails = AnsiConsole.Ask<string>("[green]Enter new contact details (email):[/]");

            var updatedPatron = new Patron(name, membershipNumber, contactDetails);

            try
            {
                await _library.patronsManager().UpdatePatron(patronId, updatedPatron);
                AnsiConsole.MarkupLine("[green]Patron updated successfully.[/]");
            }
            catch (ValidationException ex)
            {
                AnsiConsole.MarkupLine($"[red]Failed to update patron: {ex.Message}[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]An unexpected error occurred: {ex.Message}[/]");
            }
        }



        public async void RemovePatron()
        {
             string patronId = AnsiConsole.Ask<string>("[green]Enter patron Id:[/]");

             var patron = _library.patronsManager().GetPatronById(patronId);

            if (patron != null)
            {
                await _library.patronsManager().RemovePatron(patronId);
                AnsiConsole.MarkupLine("[green]Patron removed successfully.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Patron not found.[/]");
            }
        }

        public async void ListPatrons()
        {
            var existingPatron =  await _library.patronsManager().GetAllPatrons();

            if (!existingPatron.Any())
                {
                    AnsiConsole.MarkupLine("[red]No patrons found.[/]");
                    return;
                }

            var table = new Table();
            table.AddColumn("[yellow]Membership Number[/]");
            table.AddColumn("[yellow]Name[/]");
            table.AddColumn("[yellow]Contact Details[/]");
            table.AddColumn("[yellow]Current Books Borrowed[/]");
            table.AddColumn("[yellow]Borrowing History[/]");

            var rows = new List<string[]>();

            foreach (var patron in existingPatron)
                {
                    var borrowedBooks = patron.BorrowedBooks.Count > 0 ? string.Join(", ", patron.BorrowedBooks.Select(b => b.Title)) : "None";
                    var historyBooks = patron.HistoryBorrowedBooks.Count > 0 ? string.Join(", ", patron.HistoryBorrowedBooks.Select(b => b.Title)) : "None";
        
                    rows.Add(new string[]
                        {
                            patron.MembershipNumber.ToString(),
                            patron.Name,
                            patron.ContactDetails,
                            borrowedBooks,
                            historyBooks
                        });
                }

            UIUtils.PaginateTable(table, rows);
        }
    }
}
