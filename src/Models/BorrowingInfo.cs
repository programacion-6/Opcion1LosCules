namespace Opcion1LosCules;

public class BorrowingInfo
{
    public DateTime? DueDate { get; private set; }
    public DateTime? ReturnDate { get; private set; }
    public bool IsBorrowed { get; private set; } = false;
    public bool IsAvailable()
    {
        return !DueDate.HasValue || DateTime.Now > DueDate.Value;
    }

    public void MarkAsBorrowed(DateTime borrowDate)
    {
        IsBorrowed = true;
        DueDate = borrowDate.AddDays(14);
        ReturnDate = null;
    }

    public void MarkAsReturned(DateTime returnDate)
    {
        IsBorrowed = false;
        ReturnDate = returnDate;
    }

    public void SetDueDate(DateTime? dueDate)
    {
        DueDate = dueDate;
    }
}
