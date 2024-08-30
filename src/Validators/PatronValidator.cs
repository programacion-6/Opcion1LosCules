using Opcion1LosCules;

public class PatronValidator : Validator<Patron>
{
    protected override void InitializeValidations()
    {
        Validations.Add(
            "Name is required and must only contain alphabetic characters.",
            patron =>
                !string.IsNullOrEmpty(patron.Name)
                && patron.Name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c))
        );
        Validations.Add(
            "Membership number must be a positive integer.",
            patron => patron.MembershipNumber > 0
        );
        Validations.Add(
            "Contact details are required.",
            patron => !string.IsNullOrEmpty(patron.ContactDetails)
        );
        Validations.Add(
            "Patron must not have overdue books.",
            patron =>
                patron.BorrowedBooks.All(book =>
                    book.BorrowingInfo.DueDate == null
                    || DateTime.Now <= book.BorrowingInfo.DueDate.Value
                )
        );
    }
}
