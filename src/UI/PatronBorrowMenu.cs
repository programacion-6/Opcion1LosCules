namespace Opcion1LosCules;

public class PatronBorrowMenu
{
    private Library _library;
    private SearchByISBN _searchByISBN;
    private SearchByMembershipNumber _searchByMemebership;
    public PatronBorrowMenu(Library library)
    {
        _library = library;
        _searchByISBN = new();
        _searchByMemebership = new();
    }

    public void BorrowBook()
    {
        Console.Write("Enter patron membership number: ");
        var membershipNumber = Console.ReadLine();
        {
            var patron = _searchByMemebership.Search(membershipNumber, _library.patronsManager().GetAllPatrons());
            if (patron != null)
            {
                Console.Write("Enter book ISBN to borrow: ");
                var isbn = Console.ReadLine();
                var book = _searchByISBN.Search(isbn, _library.booksManager().GetAllBooks());
                if (book != null)
                {
                    _library.BorrowBook().SetPatron(patron[0]);
                    _library.BorrowBook().SetBook(book[0]);
                    _library.BorrowBook().UpdateRecords();
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
        var book = _searchByISBN.Search(isbn, _library.booksManager().GetAllBooks());
        Console.Write("Enter patron membership number: ");
        var membershipNumber = Console.ReadLine();
        var patron = _searchByMemebership.Search(membershipNumber, _library.patronsManager().GetAllPatrons());
        if (book != null)
        {
            _library.ReturnBook().SetBook(book[0]);
            _library.ReturnBook().SetPatron(patron[0]);
            _library.ReturnBook().UpdateRecords();
            Console.WriteLine("Book returned successfully.");
        }
        else
        {
            Console.WriteLine("Invalid ISBN. Please try again.");
        }
    }
}