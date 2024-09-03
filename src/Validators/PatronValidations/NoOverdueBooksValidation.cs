namespace Opcion1LosCules;

public class NoOverdueBooksValidation : IValidation<Patron>
{
    public string ErrorMessage => "Patron must not have overdue books.";

    public bool IsValid(Patron patron)
    {
        return patron.BorrowedBooks.All(book => 
            book.BorrowingInfo.DueDate == null || DateTime.Now <= book.BorrowingInfo.DueDate.Value);
    }
}
