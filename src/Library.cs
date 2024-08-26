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
        var bookStorage = new FileStorage<Book>("DataBase/BookStorage.json");
        var patronStorage = new FileStorage<Patron>("DataBase/Patrons.json");
        _booksManager = new BooksManager(bookStorage);
        _patronsManager = new PatronsManager(patronStorage);
        _borrowBook = new BorrowBook(bookStorage,patronStorage);
        _returnBook = new ReturnBook(bookStorage,patronStorage);

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