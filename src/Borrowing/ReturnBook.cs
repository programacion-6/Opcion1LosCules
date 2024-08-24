namespace Opcion1LosCules;
public class ReturnBook : BorrowingOperation
{
    public override bool Validate()
    {
        return Patron.BorrowedBooks.Contains(Book) && !Book.IsAvailable();
    }

    public override void UpdateRecords()
    {
        Console.WriteLine($"Updating records for returning book {Book.Title}.");
        
        Book.MarkAsReturned(Date);
        Patron.BorrowedBooks.Remove(Book);

        BooksManager booksManager = new BooksManager();
        booksManager.UpdateBook(Book);
        
        PatronsManager patronsManager = new PatronsManager();
        patronsManager.UpdatePatron(Patron);
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has returned the book {Book.Title}.");
    }
}