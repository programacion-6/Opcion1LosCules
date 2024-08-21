namespace Opcion1LosCules;
public abstract class BorrowingOperation
{
    protected Patron Patron { get; private set; }
    protected Book Book { get; private set; }
    protected DateTime Date { get; private set; }

    private readonly BorrowingSystemValidator _validator;

    public BorrowingOperation()
    {
        _validator = new BorrowingSystemValidator(); 
    }

    public Patron GetPatron() 
    {
        return Patron;
    }

    public Book GetBook() 
    {
        return Book;
    }

    public DateTime GetDate() 
    {
        return Date;
    }

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
        try
        {
            _validator.Validate(this);

            if (Validate())
            {
                UpdateRecords();
                NotifyPatron();
            }
            else
            {
                Console.WriteLine("Operation failed due to specific validation errors.");
            }
        }
        catch (ValidationException ex)
        {
            Console.WriteLine($"Validation failed: {ex.Message}");
        }
    }

    public abstract bool Validate();
    public abstract void UpdateRecords();
    protected abstract void NotifyPatron();
}
