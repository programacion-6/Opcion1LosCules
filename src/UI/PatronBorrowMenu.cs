using Spectre.Console;
namespace Opcion1LosCules;

public class PatronBorrowMenu
{
    private Library _library;
    private SearchByISBN? _searchByISBN;
    private SearchByMembershipNumber? _searchByMembership;
    
    public PatronBorrowMenu(Library library)
    {
        _library = library;
    }

    public void BorrowBook()
    {
        List<Patron> patrons = _library.patronsManager().GetAllPatrons();
        Patron patron = null;

        
        while (patron == null)
        {
            var membershipNumber = AnsiConsole.Ask<string>("[green]Enter patron membership number:[/]");

            if (!int.TryParse(membershipNumber, out int membershipNumberInt) || membershipNumberInt <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid membership number. Please enter a positive integer.[/]");
                continue;
            }

            _searchByMembership = new(int.Parse(membershipNumber));
            patron = _searchByMembership.Search(patrons)?.FirstOrDefault();
            if (patron == null)
            {
                AnsiConsole.MarkupLine("[red]Membership number not found. Please try again.[/]");
            }
        }

        Book book = null;

        while (book == null || book.BorrowingInfo.IsBorrowed)
        {
            var isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN to borrow:[/]");

            _searchByISBN = new(isbn);
            var books = _searchByISBN.Search(_library.booksManager().GetAllBooks());
            book = books?.FirstOrDefault();

            if (book == null)
            {
                AnsiConsole.MarkupLine("[red]Book not found. Please try again.[/]");
            }
            else if (book.BorrowingInfo.IsBorrowed)
            {
                AnsiConsole.MarkupLine("[red]The book is already borrowed. Please try another one.[/]");
            }
        }

        _library.BorrowBook().SetPatron(patron);
        _library.BorrowBook().SetBook(book);
        _library.BorrowBook().SetDate(DateTime.Now);
        _library.BorrowBook().GetBook().BorrowingInfo.IsBorrowed = true;
        _library.BorrowBook().UpdateRecords();

        AnsiConsole.MarkupLine("[bold green]Book borrowed successfully.[/]");
    }


    public void ReturnBook()
    {
        Book book = null;

        while (book == null)
        {
            var isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN to return:[/]");
            
            _searchByISBN = new(isbn);
            var books = _searchByISBN.Search(_library.booksManager().GetAllBooks());
            book = books?.FirstOrDefault();

            if (book == null)
            {
                AnsiConsole.MarkupLine("[red]Book not found. Please try again.[/]");
            }
        }

        Patron patron = null;

        while (patron == null)
        {
            var membershipNumber = AnsiConsole.Ask<string>("[green]Enter patron membership number:[/]");

            if (!int.TryParse(membershipNumber, out int membershipNumberInt) || membershipNumberInt <= 0)
            {
                AnsiConsole.MarkupLine("[red]Invalid membership number. Please enter a positive integer.[/]");
                continue;
            }
            
            _searchByMembership = new(int.Parse(membershipNumber));
            patron = _searchByMembership.Search(_library.patronsManager().GetAllPatrons())?.FirstOrDefault();

            if (patron == null)
            {
                AnsiConsole.MarkupLine("[red]Membership number not found. Please try again.[/]");
            }
        }

        _library.ReturnBook().SetBook(book);
        _library.ReturnBook().SetPatron(patron);
        _library.ReturnBook().SetDate(DateTime.Now);
        _library.ReturnBook().GetBook().BorrowingInfo.IsBorrowed = false;
        _library.ReturnBook().UpdateRecords();

        AnsiConsole.MarkupLine("[bold green]Book returned successfully.[/]");
    }
}