using Opcion1LosCules;

public abstract class BorrowingOperation
{
    protected Patron Patron { get; set; }
    protected Book Book { get; set; }
    protected DateTime Date { get; set; }

    
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