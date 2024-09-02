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

    public override void UpdateRecords()
    {
        UpdateAndNotify(
            _databaseContext,
            book => book.BorrowingInfo.MarkAsReturned(Date),
            patron => Patron.BorrowedBooks.Remove(Book));
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has returned the book {Book.Title}.");
    }
}
