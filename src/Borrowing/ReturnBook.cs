namespace Opcion1LosCules;
public class ReturnBook : BorrowingOperation
{
    private readonly IDatabaseContext _databaseContext;

    public ReturnBook(IDatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public override bool Validate()
    {
        return Patron.BorrowedBooks.Contains(Book) && !Book.BorrowingInfo.IsAvailable();
    }

    public override async void UpdateRecords()
    {
        Console.WriteLine($"Updating records for returning book {Book.Title}.");
        
        Book.BorrowingInfo.MarkAsReturned(Date);
        Patron.BorrowedBooks.Remove(Book);

        BooksManager booksManager = new BooksManager(_databaseContext);
        await booksManager.UpdateBook(Book.Id.ToString(), Book);
        
        PatronsManager patronsManager = new PatronsManager(_databaseContext);
        await patronsManager.UpdatePatron(Patron.Id.ToString(), Patron);
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has returned the book {Book.Title}.");
    }
}
