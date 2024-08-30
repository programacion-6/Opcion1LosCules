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

        private string ValidateInput(string prompt, Func<Book, string> selector, Action<Book, string> setter, string tempTitle, string tempISBN, int tempYear)
        {
            string value;
            do
            {
                value = AnsiConsole.Ask<string>(prompt);
                try
                {
                    var tempBook = new Book(tempTitle, "tempAuthor", tempISBN, "tempGenre", tempYear);
                    setter(tempBook, value);
                    new BookValidator().Validate(tempBook); 
                    break; 
                }
                catch (ValidationException ex)
                {
                    AnsiConsole.MarkupLine($"[red]{ex.Message}[/]"); 
                }
            } while (true);

            return value;
        }

        private int ValidateYear(string prompt)
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
                    AnsiConsole.MarkupLine("[red]Publication year must be a positive number.[/]");
                }
            } while (true);

            return value;
        }

        public void AddBook()
        {
            string title = AnsiConsole.Ask<string>("[green]Enter book title:[/]");

            int publicationYear = ValidateYear("[green]Enter book publication year:[/]");


            string isbn = AnsiConsole.Ask<string>("[green]Enter book ISBN:[/]");

            
    
            string author = ValidateInput("[green]Enter book author:[/]", 
                                    book => book.Author, 
                                    (book, value) => book.Author = value, 
                                    title, isbn,publicationYear);

            string genre = ValidateInput("[green]Enter book genre:[/]", 
                                   book => book.Genre, 
                                   (book, value) => book.Genre = value, 
                                   title, isbn,publicationYear);

            var book = new Book(title, author, isbn, genre, publicationYear);
    
            try
            {
                _library.booksManager().AddBook(book);
                AnsiConsole.MarkupLine("[green]Book added successfully.[/]");
            }
            catch (ValidationException ex)
            {
                AnsiConsole.MarkupLine($"[red]Failed to add book: {ex.Message}[/]");
            }
            catch (Exception ex)
            {
                AnsiConsole.MarkupLine($"[red]An unexpected error occurred: {ex.Message}[/]");
            }
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

            var isbn = AnsiConsole.Ask<string>("[green]Enter new book ISBN:[/]");
            int publicationYear = ValidateYear("[green]Enter book publication year:[/]");

            var author = ValidateInput("[green]Enter book author:[/]", 
                                    book => book.Author, 
                                    (book, value) => book.Author = value, 
                                    title, isbn,publicationYear);

            var genre = ValidateInput("[green]Enter book genre:[/]", 
                                   book => book.Genre, 
                                   (book, value) => book.Genre = value, 
                                   title, isbn,publicationYear);

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

            UIUtils.PaginateTable(new StandardPagination() ,table, rows);
        }

    }
}
