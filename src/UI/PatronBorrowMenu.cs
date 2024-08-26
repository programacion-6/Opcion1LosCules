using Spectre.Console;
namespace Opcion1LosCules;

public class PatronBorrowMenu
{
    private Library _library;
    private SearchByISBN _searchByISBN;
    private SearchByMembershipNumber _searchByMembership;
    public PatronBorrowMenu(Library library)
    {
        _library = library;
        _searchByISBN = new();
        _searchByMembership = new();
    }

    public void BorrowBook()
    {
        List<Patron> patrons = _library.patronsManager().GetAllPatrons();
        Patron patron = null;

        
        while (patron == null)
        {
            var membershipNumber = AnsiConsole.Ask<string>("[green]Enter patron membership number:[/]");

            // Validar si el número de membresía es válido
            if (!int.TryParse(membershipNumber, out int membershipNumberInt) || membershipNumberInt <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid membership number. Please enter a positive integer.[/]");
                continue;
            }

            // Buscar al patron en la lista
            patron = _searchByMembership.Search(membershipNumber, patrons)?.FirstOrDefault();
            if (patron == null)
            {
                AnsiConsole.MarkupLine("[red]Membership number not found. Please try again.[/]");
            }
        }

        Book book = null;

        // Repetir hasta que se ingrese un ISBN válido y el libro esté disponible
        while (book == null || book.IsBorrowed)
        {
            var isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN to borrow:[/]");

            // Buscar el libro en la lista utilizando SearchByISBN
            var books = _searchByISBN.Search(isbn, _library.booksManager().GetAllBooks());
            book = books?.FirstOrDefault();

            if (book == null)
            {
                AnsiConsole.MarkupLine("[red]Book not found. Please try again.[/]");
            }
            else if (book.IsBorrowed)
            {
                AnsiConsole.MarkupLine("[red]The book is already borrowed. Please try another one.[/]");
            }
        }

        // Proceder con el préstamo del libro
        _library.BorrowBook().SetPatron(patron);
        _library.BorrowBook().SetBook(book);
        _library.BorrowBook().SetDate(DateTime.Now);
        _library.BorrowBook().GetBook().IsBorrowed = true;
        _library.BorrowBook().UpdateRecords();

        AnsiConsole.MarkupLine("[bold green]Book borrowed successfully.[/]");
    }


    public void ReturnBook()
    {
        Book book = null;

        // Repetir hasta que se ingrese un ISBN válido
        while (book == null)
        {
            var isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN to return:[/]");
        
            // Buscar el libro en la lista utilizando SearchByISBN
            var books = _searchByISBN.Search(isbn, _library.booksManager().GetAllBooks());
            book = books?.FirstOrDefault();

            if (book == null)
            {
                AnsiConsole.MarkupLine("[red]Book not found. Please try again.[/]");
            }
        }

        Patron patron = null;

        // Repetir hasta que se ingrese un número de membresía válido y existente
        while (patron == null)
        {
            var membershipNumber = AnsiConsole.Ask<string>("[green]Enter patron membership number:[/]");

            // Validar si el número de membresía es válido
            if (!int.TryParse(membershipNumber, out int membershipNumberInt) || membershipNumberInt <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid membership number. Please enter a positive integer.[/]");
                continue;
            }

            // Buscar al patron en la lista utilizando SearchByMembershipNumber
            patron = _searchByMembership.Search(membershipNumber, _library.patronsManager().GetAllPatrons())?.FirstOrDefault();

            if (patron == null)
            {
                AnsiConsole.MarkupLine("[red]Membership number not found. Please try again.[/]");
            }
        }

        // Proceder con la devolución del libro
        _library.ReturnBook().SetBook(book);
        _library.ReturnBook().SetPatron(patron);
        _library.ReturnBook().SetDate(DateTime.Now);
        _library.ReturnBook().GetBook().IsBorrowed = false;
        _library.ReturnBook().UpdateRecords();

        AnsiConsole.MarkupLine("[bold green]Book returned successfully.[/]");
    }
}