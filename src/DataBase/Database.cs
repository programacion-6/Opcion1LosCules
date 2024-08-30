using Opcion1LosCules;

public class Database : IDatabaseContext<IEntity>
{
    private readonly Dictionary<string, Book> _bookStorage = [];
    private readonly Dictionary<string, Patron> _patronStorage = [];
    private readonly int _okCode = 200;
    private readonly int _badRequestCode = 400;
    public int Add(IEntity entity)
    {
        switch(entity)
        {
            case Book book:
            _bookStorage.Add(book.Id.ToString() ,book);
            return _okCode;
            case Patron patron:
            _patronStorage.Add(patron.Id.ToString(), patron);
            return _okCode;
            default:
            return _badRequestCode;
        }
    }

    public int Delete(IEntity entity)
    {
        switch(entity)
        {
            case Book book:
            _bookStorage.Remove(book.Id.ToString());
            return _okCode;
            case Patron patron:
            _patronStorage.Remove(patron.Id.ToString());
            return _okCode;
            default:
            return _badRequestCode;
        }
    }

    public IEntity GetById(string id)
    {
        if(_bookStorage.ContainsKey(id))
        {
            return _bookStorage[id];
        }
        if (_patronStorage.ContainsKey(id))
        {
            return _patronStorage[id];
        }
        throw new Exception("Element not found.");
    }

    public int Update(string id, IEntity entity)
    {
        switch(entity)
        {
            case Book book:
            if(_bookStorage.ContainsKey(id))
            {
                UpdateBook(_bookStorage[id], book);
                return _okCode;
            }
            else
            {
                return _badRequestCode;
            }
            case Patron patron:
            if(_patronStorage.ContainsKey(id))
            {
                UpdatePatron(_patronStorage[id], patron);
                return _okCode;
            }
            else
            {
                return _badRequestCode;
            }
            default:
            return _badRequestCode;
        }
    }

    private void UpdateBook(Book actual, Book newer)
    {
        actual.Author = newer.Author;
        actual.ISBN = newer.ISBN;
        actual.Genre = newer.Genre;
        actual.PublicationYear = newer.PublicationYear;
        actual.DueDate = newer.DueDate;
        actual.ReturnDate = newer.ReturnDate;
        actual.IsBorrowed = newer.IsBorrowed;
    }

    private void UpdatePatron(Patron actual, Patron newer)
    {
        actual.Name = newer.Name;
        actual.MembershipNumber = newer.MembershipNumber;
        actual.ContactDetails = newer.ContactDetails;
        actual.BorrowedBooks = newer.BorrowedBooks;
        actual.BorrowedBooks = newer.BorrowedBooks;
        actual.HistoryBorrowedBooks = newer.HistoryBorrowedBooks;
    }
}