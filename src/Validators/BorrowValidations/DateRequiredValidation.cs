namespace Opcion1LosCules;

public class DateRequiredValidation : IValidation<BorrowingOperation>
{
    public string ErrorMessage => "Date must be set.";

    public bool IsValid(BorrowingOperation operation)
    {
        return operation.GetDate() != default(DateTime)
            && operation.GetDate() >= operation.GetDueDate();
    }
}
