using Opcion1LosCules;

public class PatronValidator : Validator<Patron>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Name is required.", patron => !string.IsNullOrEmpty(patron.Name));
        Validations.Add("Membership number must be a positive integer.", patron => patron.MembershipNumber > 0);
        Validations.Add("Contact details are required.", patron => !string.IsNullOrEmpty(patron.ContactDetails));
        Validations.Add("Patron must not have overdue books.", patron => patron.BorrowedBooks.All(book => book.DueDate == null || DateTime.Now <= book.DueDate.Value));
    }
}