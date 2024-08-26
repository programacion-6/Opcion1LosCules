using Spectre.Console;
namespace Opcion1LosCules
{
    public class BooksManagementMenu
    {
        private Library _library;

        public BooksManagementMenu(Library library)
        {
            _library = library;
        }

        public void AddBook()
        {
            var title = AnsiConsole.Ask<string>("[green]Enter book title:[/]");
            var author = AnsiConsole.Ask<string>("[green]Enter book author:[/]");
            var isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN:[/]");
            var genre = AnsiConsole.Ask<string>("[green]Enter book genre:[/]");
            int publicationYear = AnsiConsole.Ask<int>("[green]Enter book publication year:[/]");
           
            var book = new Book(title, author, isbn, genre, publicationYear);
            _library.booksManager().AddBook(book);
            AnsiConsole.MarkupLine("[green]Book added successfully.[/]");
        }

        public void UpdateBook()
        {
            var title = AnsiConsole.Ask<string>("[green]Enter the title of the book to update:[/]");
            var existingBook = _library.booksManager().GetAllBooks()
                .FirstOrDefault(b => b.Title == title);

            if (existingBook == null)
            {
                AnsiConsole.MarkupLine("[red]No book found with that title. Please try again.[/]");
                return;
            }

            var author = AnsiConsole.Ask<string>("[green]Enter new book author:[/]");
            var isbn = AnsiConsole.Ask<string>("[green]Enter new book ISBN:[/]");
            var genre = AnsiConsole.Ask<string>("[green]Enter new book genre:[/]");
            int publicationYear = AnsiConsole.Ask<int>("[green]Enter book publication year:[/]");

            var updatedBook = new Book(title, author, isbn, genre, publicationYear);
            _library.booksManager().UpdateBook(updatedBook);
            AnsiConsole.MarkupLine("[green]Book updated successfully.[/]");
        }

        public void RemoveBook()
        {
            var title = AnsiConsole.Ask<string>("[green]Enter the title of the book to remove:[/]");
            var existingBook = _library.booksManager().GetAllBooks()
                .FirstOrDefault(b => b.Title == title);

            if (existingBook != null)
            {
                _library.booksManager().RemoveBook(existingBook);
                AnsiConsole.MarkupLine("[green]Book removed successfully.[/]");
            }
            else
            {
                AnsiConsole.MarkupLine("[red]No book found with that title.[/]");
            }
        }

        public void ListBooks()
        { 
            AnsiConsole.MarkupLine("[yellow]Listing Books by Genre:[/]");
            var existingBook = _library.booksManager().GetAllBooks()
                .OrderBy(book => book.Genre)
                .ToList();

            if (existingBook.Count == 0)
            {
                AnsiConsole.MarkupLine("[red]No books found.[/]");
                return;
            }

            var table = new Table();
            table.AddColumn("[yellow]Title[/]");
            table.AddColumn("[yellow]Author[/]");
            table.AddColumn("[yellow]Genre[/]");
            table.AddColumn("[yellow]Publication Year[/]");

            var rows = new List<string[]>();

            foreach (var book in existingBook)
            {
                rows.Add(new string[]
                {
                    book.Title,
                    book.Author,
                    book.Genre,
                    book.PublicationYear.ToString()
                });
            }

            UIUtils.PaginateTable(table, rows);
        }

    }
}
