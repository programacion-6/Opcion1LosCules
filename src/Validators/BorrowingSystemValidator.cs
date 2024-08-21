using Opcion1LosCules;

public class BorrowingSystemValidator : Validator<BorrowingOperation>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Patron is required.", operation => operation.GetPatron() != null);
        Validations.Add("Book is required.", operation => operation.GetBook() != null);
        Validations.Add("Date must be set.", operation => operation.GetDate() != default(DateTime));
        Validations.Add("Book must be available for borrowing.", operation => operation is BorrowBook && operation.GetBook().IsAvailable());
        Validations.Add("Patron must not already have the book borrowed.", operation => operation is BorrowBook && !operation.GetPatron().BorrowedBooks.Contains(operation.GetBook()));
        Validations.Add("Book must be borrowed by the patron for return.", operation => operation is ReturnBook && operation.GetPatron().BorrowedBooks.Contains(operation.GetBook()));
        Validations.Add("Book must not be already returned.", operation => operation is ReturnBook && !operation.GetBook().IsAvailable());
    }
}