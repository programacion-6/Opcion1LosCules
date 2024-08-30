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
        Console.WriteLine($"Updating records for returning book {Book.Title}.");
        
        Book.BorrowingInfo.MarkAsReturned(Date);
        Patron.BorrowedBooks.Remove(Book);

        BooksManager booksManager = new BooksManager(_bookStorage);
        booksManager.UpdateItem(Book);
        
        PatronsManager patronsManager = new PatronsManager(_patronStorage);
        patronsManager.UpdateItem(Patron);
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has returned the book {Book.Title}.");
    }
}
