namespace Opcion1LosCules;

public class Patron 
{
    private string _name;
    private int _membershipNumber;
    private string _contactDetails;
    private readonly List<Book> _borrowedBooks;
    private readonly List<Book> _historyBorrowedBooks;

    public Patron(string name,int membershipNumber, string contactDetails)
    {
        _name = name;
        _membershipNumber = membershipNumber;
        _contactDetails = contactDetails;
        _borrowedBooks = new();
        _historyBorrowedBooks = new();
    }
    public string Name 
    {
        get { return _name; }
        set { _name = value; }
    }
    public int MembershipNumber 
    {
        get { return _membershipNumber; }
        set { _membershipNumber = value; }
    }
    public string ContactDetails 
    {
        get { return _contactDetails ; }
        set { _contactDetails  = value; }
    }
    public List<Book> BorrowedBooks 
    {
        get { return _borrowedBooks ; }
        set 
        {
            _borrowedBooks.Clear();
            if (value != null)
            {
                _borrowedBooks.AddRange(value);
            }
        }
    }

    public List<Book> HistoryBorrowedBooks 
    {
        get { return _historyBorrowedBooks ; }
        set 
        {
            _historyBorrowedBooks.Clear();
            if (value != null)
            {
                _historyBorrowedBooks.AddRange(value);
            }
        }
    }

    public override string ToString()
    {
        return $"Patron:\n"
            + $"Name: {Name}\n"
            + $"MembershipNumber: {MembershipNumber}\n"
            + $"ContactDetails: {ContactDetails}";
    }
}