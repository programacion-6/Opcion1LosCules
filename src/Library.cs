namespace Opcion1LosCules;

public class Library
{
    private BooksManager _booksManager;
    private PatronsManager _patronsManager;
    private BorrowBook _borrowBook;
    private ReturnBook _returnBook;
    private BorrowingOperation _borrowingOperation = default!;
    public Library()
    {
        var databaseContext = new Database();
        _booksManager = new BooksManager(databaseContext);
        _patronsManager = new PatronsManager(databaseContext);
        _borrowBook = new BorrowBook(databaseContext);
        _returnBook = new ReturnBook(databaseContext);

    }

    public PatronsManager patronsManager() 
    {
        return _patronsManager;
    }

    public BooksManager booksManager() 
    {
        return _booksManager; 
    }

    public BorrowBook BorrowBook() 
    {
        return _borrowBook;
    }

     public ReturnBook ReturnBook() 
    {
        return _returnBook;
    }

    public BorrowingOperation BorrowOperation() 
    {
        return _borrowingOperation;
    }
}