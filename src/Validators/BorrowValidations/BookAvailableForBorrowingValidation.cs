namespace Opcion1LosCules;

public class BookAvailableForBorrowingValidation : IValidation<BorrowingOperation>
{
    public string ErrorMessage => "Book must be available for borrowing.";

    public bool IsValid(BorrowingOperation operation)
    {
        return operation is BorrowBook && operation.GetBook().BorrowingInfo.IsAvailable();
    }
}
