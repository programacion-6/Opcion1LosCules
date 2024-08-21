namespace Opcion1LosCules;
public class BorrowBook : BorrowingOperation
{
    private bool CheckAvailability()
    {
        return Book.IsAvailable();
    }

    protected override bool Validate()
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

    protected override void UpdateRecords()
    {
        
        Console.WriteLine($"Updating records for borrowing book {Book.Title}.");
       
        Book.MarkAsBorrowed(Date);
        Patron.BorrowedBooks.Add(Book);
    }

    protected override void NotifyPatron()
    {
        Console.WriteLine($"Patron {Patron.Name} has borrowed the book {Book.Title}.");
    }
}