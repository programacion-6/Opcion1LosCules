namespace Opcion1LosCules;
public class ReturnBook : BorrowingOperation
{
    private IStorage<Book> _bookStorage;
    private IStorage<Patron> _patronStorage;

    public ReturnBook(IStorage<Book> bookStorage, IStorage<Patron> patronStorage)
    {
        _bookStorage = bookStorage;
        _patronStorage = patronStorage;
    }

    public override bool Validate()
    {
        return Patron.BorrowedBooks.Contains(Book) && !Book.BorrowingInfo.IsAvailable();
    }

    public override void UpdateRecords()
    {
        UpdateAndNotify(
            _bookStorage,
            _patronStorage,
            book => book.BorrowingInfo.MarkAsReturned(Date),
            patron => Patron.BorrowedBooks.Remove(Book));
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has returned the book {Book.Title}.");
    }
}
