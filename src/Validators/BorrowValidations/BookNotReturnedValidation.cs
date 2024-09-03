namespace Opcion1LosCules;

public class BookNotReturnedValidation : IValidation<BorrowingOperation>
{
    public string ErrorMessage => "Book must not be already returned.";

    public bool IsValid(BorrowingOperation operation)
    {
        return operation is ReturnBook && !operation.GetBook().BorrowingInfo.IsAvailable();
    }
}
