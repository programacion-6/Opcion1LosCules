namespace Opcion1LosCules;

public class BorrowingInfo
{
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public bool IsBorrowed { get; set; } = false;
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
