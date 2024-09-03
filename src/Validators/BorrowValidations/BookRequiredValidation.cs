namespace Opcion1LosCules;

public class BookRequiredValidation : IValidation<BorrowingOperation>
{
    public string ErrorMessage => "Book is required.";

    public bool IsValid(BorrowingOperation operation)
    {
        return operation.GetBook() != null;
    }
}
