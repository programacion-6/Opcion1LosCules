namespace Opcion1LosCules;
using Spectre.Console;
using System.Collections.Generic;
using System.Linq;
public class BookSearchMenu
{
    private readonly BooksManager _bookManager;
        
    public BookSearchMenu(BooksManager bookManager)
    {
        _bookManager = bookManager;
    }

    public async void DisplaySearchMenu()
    {
        var option = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                    .Title("[yellow]Select search criteria:[/]")
                    .AddChoices("Search by Title", "Search by Author", "Search by ISBN"));

            // Solicitar el término de búsqueda
        var query = AnsiConsole.Ask<string>("[green]Enter search term:[/]");

        if (string.IsNullOrWhiteSpace(query))
        {
            AnsiConsole.MarkupLine("[red]Search term cannot be empty.[/]");
            return;
        }
            
        List<Book> searchResults = new();
            
        switch (option)
        {
            case "Search by Title":
                searchResults = await SearchByTitle(query);
                break;
            case "Search by Author":
                searchResults = await SearchByAuthor(query);
                break;
            case "Search by ISBN":
                searchResults = await SearchByISBN(query);
                break;
            default:
                AnsiConsole.MarkupLine("[red]Invalid option.[/]");
                break;
        }

        DisplaySearchResults(searchResults);
    }

    public async Task<List<Book>> SearchByTitle(string title)
    {
        var strategy = new SearchByTitle(title);
        return strategy.Search((await _bookManager.GetAllBooks()).ToList());
    }

    public async Task<List<Book>> SearchByAuthor(string author)
    {
        var strategy = new SearchByAuthor(author);
        return strategy.Search((await _bookManager.GetAllBooks()).ToList());
    }

    public async Task<List<Book>> SearchByISBN(string isbn)
    {
        var strategy = new SearchByISBN(isbn);
        return strategy.Search((await _bookManager.GetAllBooks()).ToList());
    }

    private void DisplaySearchResults(List<Book> books)
    {
        if (books.Any())
        {
            var table = new Table();

                table.AddColumn(new TableColumn("Title"));
                table.AddColumn(new TableColumn("Author"));
                table.AddColumn(new TableColumn("ISBN"));

            foreach (var book in books)
            {
                table.AddRow(new Markup(book.Title), new Markup(book.Author), new Markup(book.ISBN));
            }
            AnsiConsole.Write(table);
        }
        else
        {
            AnsiConsole.MarkupLine("[red]No results found.[/]");
        }
    }
}

