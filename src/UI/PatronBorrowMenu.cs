using Spectre.Console;

namespace Opcion1LosCules;

public class PatronBorrowMenu
{
    private Library _library;
    
    public PatronBorrowMenu(Library library)
    {
        _library = library;
    }

    public void BorrowBook()
    {
        Patron patron = UIUtils.DisplaySelectableListResult(_library.patronsManager().Items);
        Book book = UIUtils.DisplaySelectableListResult(_library.booksManager().Items);

        if (book.BorrowingInfo.IsBorrowed)
        {
            AnsiConsole.MarkupLine("[red]The book is already borrowed. Please try another one.[/]");
            return;
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
        Book book = UIUtils.DisplaySelectableListResult(_library.booksManager().Items);

        if(book.BorrowingInfo.IsBorrowed == false) {
            AnsiConsole.MarkupLine("[red]The book is not currently borrowed.[/]");
            return;
        }

        Patron patron = UIUtils.DisplaySelectableListResult(_library.patronsManager().Items);

        if(!patron.BorrowedBooks.Contains(book)) {
            AnsiConsole.MarkupLine("[red]The book is not currently borrowed by this patron.[/]");
            return;
        }

        _library.ReturnBook().SetBook(book);
        _library.ReturnBook().SetPatron(patron);
        _library.ReturnBook().SetDate(DateTime.Now);
        _library.ReturnBook().GetBook().BorrowingInfo.IsBorrowed = false;
        _library.ReturnBook().UpdateRecords();

        AnsiConsole.MarkupLine("[bold green]Book returned successfully.[/]");
    }
}
