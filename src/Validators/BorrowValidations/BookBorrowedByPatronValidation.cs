namespace Opcion1LosCules;

public class BookBorrowedByPatronValidation : IValidation<BorrowingOperation>
{
    public string ErrorMessage => "Book must be borrowed by the patron for return.";

    public bool IsValid(BorrowingOperation operation)
    {
        return operation is ReturnBook && operation.GetPatron().BorrowedBooks.Contains(operation.GetBook());
    }
}
