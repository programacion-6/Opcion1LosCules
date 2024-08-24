namespace Opcion1LosCules;
public class BorrowBook : BorrowingOperation
{
    private bool CheckAvailability()
    {
        return Book.IsAvailable();
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

    public override void UpdateRecords()
    {
        Console.WriteLine($"Updating records for borrowing book {Book.Title}.");
       
        Book.MarkAsBorrowed(Date);
        Patron.BorrowedBooks.Add(Book);
        Patron.HistoryBorrowedBooks.Add(Book);

        BooksManager booksManager = new BooksManager();
        booksManager.UpdateBook(Book);

        PatronsManager patronsManager = new PatronsManager();
        patronsManager.UpdatePatron(Patron);
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