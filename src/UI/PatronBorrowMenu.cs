namespace Opcion1LosCules;

public class PatronBorrowMenu
{
    private Library _library;
    private IBookSearchStrategy _bookSearchStrategy;
    private IPatronSearchStrategy _patronSearchStrategy;
    public PatronBorrowMenu(Library library)
    {
        _library = library;
    }

    public void BorrowBook()
    {
        Console.Write("Enter patron membership number: ");
        var membershipNumber = Console.ReadLine();
        {
            var patron = _patronSearchStrategy.Search(membershipNumber,_library.GetAllPatrons());
            if (patron != null)
            {
                Console.Write("Enter book ISBN to borrow: ");
                var isbn = Console.ReadLine();
                var book = _bookSearchStrategy.Search(isbn,_library.GetAllBooks());
                if (book != null)
                {
                    _library.BorrowOperation();
                    Console.WriteLine("Book borrowed successfully.");
                }
                else
                {
                    Console.WriteLine("Book not found. Please try again.");
                }
            }
            else
            {
                Console.WriteLine("Invalid membership number. Please try again.");
            }
        }
    }


    public void ReturnBook()
    {
        Console.Write("Enter book ISBN to return: ");
        var isbn = Console.ReadLine();
        var book = _bookSearchStrategy.Search(isbn,_library.GetAllBooks());
        if (book != null)
        {
            _library.BorrowOperation();
            Console.WriteLine("Book returned successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ISBN. Please try again.");
        }
    }
}