namespace Opcion1LosCules;

public class Book : IEntity
{
    public Guid Id { get; set; }
    private string _title;
    private string _author;
    private string _ISBN;
    private string _genre;
    private int _publicationYear;
    public BorrowingInfo BorrowingInfo { get; set; }

    public Book(string title, string author, string ISBN, string genre, int publicationYear) 
    {
        Id = Guid.NewGuid();
        _title = title;
        _author = author;
        _ISBN = ISBN;
        _genre = genre;
        _publicationYear = publicationYear;
        BorrowingInfo = new BorrowingInfo();
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

    public override string ToString()
    {
        return $"Book:\n"
            + $"Title: {Title}\n"
            + $"Author: {Author}\n"
            + $"ISBN: {ISBN}\n"
            + $"Genre: {Genre}\n"
            + $"PublicationYear: {PublicationYear}\n";
    }
}