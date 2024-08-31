namespace Opcion1LosCules;
public class BorrowBook : BorrowingOperation
{
    private readonly IDatabaseContext _databaseContext;

    public BorrowBook(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    private bool CheckAvailability()
    {
        return Book.BorrowingInfo.IsAvailable();
    }

    public override bool Validate()
    {
        if (CheckAvailability())
        {
            if (Patron.BorrowedBooks.Contains(Book))
            {
                Console.WriteLine($"Patron already borrowed the book {Book.Title}.");
                return false;
            }
            return true;
        }
        Console.WriteLine($"Book {Book.Title} is not available.");
        return false;
    }

    public override async void UpdateRecords()
    {
        Console.WriteLine($"Updating records for borrowing book {Book.Title}.");
        
        Book.BorrowingInfo.MarkAsBorrowed(Date);
        Patron.BorrowedBooks.Add(Book);
        Patron.HistoryBorrowedBooks.Add(Book);

        BooksManager booksManager = new BooksManager(_databaseContext);
        await booksManager.UpdateBook(Book.Id.ToString(), Book);

        PatronsManager patronsManager = new PatronsManager(_databaseContext);
        await patronsManager.UpdatePatron(Patron.Id.ToString(), Patron);
    }

    public void HistoryBorrowingUpdateRecords()
    {  
        Patron.HistoryBorrowedBooks.Add(Book);
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has borrowed the book {Book.Title}.");
    }
}
