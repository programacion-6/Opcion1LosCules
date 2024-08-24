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
         var membershipNumber = AnsiConsole.Ask<string>("[green]Enter patron membership number:[/]");

            var patron = _searchByMembership.Search(membershipNumber, _library.patronsManager().GetAllPatrons());
            if (patron != null)
            {
                var isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN to borrow:[/]");
                var book = _searchByISBN.Search(isbn, _library.booksManager().GetAllBooks());
                if (book != null && !book[0].IsBorrowed)
                {
                    _library.BorrowBook().SetPatron(patron[0]);
                    _library.BorrowBook().SetBook(book[0]);
                    _library.BorrowBook().SetDate(DateTime.Now);
                    _library.BorrowBook().GetBook().IsBorrowed = true;
                    _library.BorrowBook().UpdateRecords();
                    
                    AnsiConsole.MarkupLine("[bold green]Book borrowed successfully.[/]");
                }
                else
                {
                    AnsiConsole.MarkupLine("[red]Book not found. Please try again.[/]");
                }
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Invalid membership number. Please try again.[/]");
            }
    }


    public void ReturnBook()
    {
        var isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN to return:[/]");
            var book = _searchByISBN.Search(isbn, _library.booksManager().GetAllBooks());
            
            var membershipNumber = AnsiConsole.Ask<string>("[green]Enter patron membership number:[/]");
            var patron = _searchByMembership.Search(membershipNumber, _library.patronsManager().GetAllPatrons());

            if (book != null)
            {
                _library.ReturnBook().SetBook(book[0]);
                _library.ReturnBook().SetPatron(patron[0]);
                _library.ReturnBook().SetDate(DateTime.Now);
                _library.ReturnBook().GetBook().IsBorrowed = false;
                _library.ReturnBook().UpdateRecords();
                AnsiConsole.MarkupLine("[bold green]Book returned successfully.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]Invalid ISBN. Please try again.[/]");
            }
    }
}