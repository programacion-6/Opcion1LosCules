namespace Opcion1LosCules;

public class Library
{
    private BooksManager _booksManager;
    private PatronsManager _patronsManager;
    private BorrowBook _borrowBook;
    private ReturnBook _returnBook;
    private BorrowingOperation _borrowingOperation;

    public Library()
    {
        _booksManager = new BooksManager();
        _patronsManager = new PatronsManager();
        _borrowBook = new BorrowBook();
        _returnBook = new ReturnBook();

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