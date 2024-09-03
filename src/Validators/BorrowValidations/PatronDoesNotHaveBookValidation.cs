namespace Opcion1LosCules;

public class PatronDoesNotHaveBookValidation : IValidation<BorrowingOperation>
{
    public string ErrorMessage => "Patron must not already have the book borrowed.";

    public bool IsValid(BorrowingOperation operation)
    {
        return operation is BorrowBook && !operation.GetPatron().BorrowedBooks.Contains(operation.GetBook());
    }
}
