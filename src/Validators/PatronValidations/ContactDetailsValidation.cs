namespace Opcion1LosCules;

public class ContactDetailsValidation : IValidation<Patron>
{
    public string ErrorMessage => "Contact details are required.";

    public bool IsValid(Patron patron)
    {
        return !string.IsNullOrEmpty(patron.ContactDetails);
    }
}
