public class BorrowBook : BorrowingOperation
{
    private bool CheckAvailability()
    {
        // Check if the book is available
        return Book.IsAvailable();
    }

    protected override bool Validate()
    {
        // Validate if the book can be borrowed
        if (CheckAvailability())
        {
            // Check if the patron has already borrowed this book
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