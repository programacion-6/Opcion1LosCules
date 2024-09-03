namespace Opcion1LosCules;
public class PatronRequiredValidation : IValidation<BorrowingOperation>
{
    public string ErrorMessage => "Patron is required.";

    public bool IsValid(BorrowingOperation operation)
    {
        return operation.GetPatron() != null;
    }
}
