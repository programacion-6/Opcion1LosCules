namespace Opcion1LosCules;
public class BookSearchMenu
{
    private readonly BooksManager _bookManager;
        
    public BookSearchMenu(BooksManager bookManager)
    {
        _bookManager = bookManager;
    }

    public void DisplaySearchMenu()
    {
        Console.WriteLine("Select search criteria:");
        Console.WriteLine("1. Search by Title");
        Console.WriteLine("2. Search by Author");
        Console.WriteLine("3. Search by ISBN");
            
        var option = Console.ReadLine();
        Console.WriteLine("Enter search term:");
        var query = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(query))
        {
            Console.WriteLine("Search term cannot be empty.");
            return;
        }
            
        List<Book> searchResults = new();
            
        switch (option)
        {
            case "1":
                searchResults = SearchByTitle(query);
                break;
            case "2":
                searchResults = SearchByAuthor(query);
                break;
            case "3":
                searchResults = SearchByISBN(query);
                break;
            default:
                Console.WriteLine("Invalid option.");
                break;
        }

        DisplaySearchResults(searchResults);
    }
    public List<Book> SearchByTitle(string title)
    {
        var strategy = new SearchByTitle();
        return strategy.Search(title, _bookManager.GetAllBooks());
    }

    public List<Book> SearchByAuthor(string author)
    {
        var strategy = new SearchByAuthor();
        return strategy.Search(author, _bookManager.GetAllBooks());
    }

    public List<Book> SearchByISBN(string isbn)
    {
        var strategy = new SearchByISBN();
        return strategy.Search(isbn, _bookManager.GetAllBooks());
    }

    private void DisplaySearchResults(List<Book> books)
    {
        if (books.Any())
        {
            Console.WriteLine("Search results:");
            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, ISBN: {book.ISBN}");
            }
        }
        else
        {
            Console.WriteLine("No results found.");
        }
    }
}

