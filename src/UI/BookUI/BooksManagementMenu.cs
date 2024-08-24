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

        public void ListBooksByGenre()
        {
            AnsiConsole.MarkupLine("[yellow]Listing Books by Genre:[/]");
            var existingBook = _library.booksManager().GetAllBooks()
            .GroupBy(book => book.Genre)
            .OrderBy(group => group.Key);

            foreach (var group in existingBook)
            {
                AnsiConsole.MarkupLine($"[yellow]Genre: {group.Key}[/]");
                foreach (var book in group)
                {
                    AnsiConsole.MarkupLine($"  - [blue]{book.Title}[/] ([green]{book.Author}[/], {book.PublicationYear})");
                }
            }
            
        }

    }
}
