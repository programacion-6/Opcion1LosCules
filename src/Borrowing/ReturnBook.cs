public class ReturnBook : BorrowingOperation
{
    protected override bool Validate()
    {
        return Patron.BorrowedBooks.Contains(Book) && !Book.IsAvailable();
    }

    protected override void UpdateRecords()
    {
        Console.WriteLine($"Updating records for returning book {Book.Title}.");
        
        Book.MarkAsReturned(Date);
        Patron.BorrowedBooks.Remove(Book);
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has returned the book {Book.Title}.");
    }
}