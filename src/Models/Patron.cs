namespace Opcion1LosCules;

public class Patron 
{
    private string _name;
    private int _membershipNumber;
    private string _contactDetails;
    private readonly List<Book> borrowedBooks;

    public Patron(string name,int membershipNumber, string contactDetails)
    {
        _name = name;
        _membershipNumber = membershipNumber;
        _contactDetails = contactDetails;
        borrowedBooks = new();
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
        get { return borrowedBooks ; }
    }
}