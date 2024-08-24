namespace Opcion1LosCules;

public class Book 
{
    private string _title;
    private string _author;
    private string _ISBN;
    private string _genre;
    private int _publicationYear;
    public DateTime? DueDate { get; set; }
    public DateTime? ReturnDate { get; set; }


    public Book(string title, string author, string ISBN, string genre, int publicationYear) 
    {
        _title = title;
        _author = author;
        _ISBN = ISBN;
        _genre = genre;
        _publicationYear = publicationYear;

    }

    public string Title 
    {
        get { return _title; }
        set { _title = value; }
    }

    public string Author 
    {
        get { return _author; }
        set { _author = value; }
    }

    public string ISBN
    {
        get { return _ISBN; }
        set { _ISBN = value; }
    }

    public string Genre 
    {
        get { return _genre; }
        set { _genre = value; }
    }

    public int PublicationYear 
    {
        get { return _publicationYear; }
        set { _publicationYear = value; }
    }  



    public bool IsAvailable()
    {
        
        return !DueDate.HasValue || DateTime.Now > DueDate.Value;
    }

    
    public void MarkAsBorrowed(DateTime borrowDate)
    {
        
        DueDate = borrowDate.AddDays(14);
        ReturnDate = null; 
    }

   
    public void MarkAsReturned(DateTime returnDate)
    {
        
        ReturnDate = returnDate;
        DueDate = null; 
    }
}