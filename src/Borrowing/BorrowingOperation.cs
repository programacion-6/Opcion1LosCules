namespace Opcion1LosCules;
public abstract class BorrowingOperation
{
    protected Patron Patron { get; private set; }
    protected Book Book { get; private set; }
    protected DateTime Date { get; private set; }

    public void SetPatron(Patron patron)
    {
        Patron = patron;
    }

    public void SetBook(Book book)
    {
        Book = book;
    }

    public void SetDate(DateTime date)
    {
        Date = date;
    }

    public void Execute()
    {
        if (Validate())
        {
            UpdateRecords();
            NotifyPatron();
        }
        else
        {
            Console.WriteLine("Operation failed due to validation errors.");
        }
    }

    protected abstract bool Validate();
    protected abstract void UpdateRecords();
    protected abstract void NotifyPatron();
}
