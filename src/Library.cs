namespace Opcion1LosCules;

public class Library
{
    private BooksManager _booksManager;
    private PatronsManager _patronsManager;
    private BorrowingOperation _borrowingOperation;

    public Library()
    {
        _booksManager = new BooksManager();
        _patronsManager = new PatronsManager();
    }

    public PatronsManager patronsManager() 
    {
        return _patronsManager;
    }

    public BooksManager booksManager() 
    {
        return _booksManager; 
    }

    public BorrowingOperation BorrowOperation() 
    {
        return _borrowingOperation;
    }
}