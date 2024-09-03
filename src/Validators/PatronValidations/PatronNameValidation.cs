namespace Opcion1LosCules;
public class PatronNameValidation : IValidation<Patron>
{
    public string ErrorMessage => "Name is required and must only contain alphabetic characters.";

    public bool IsValid(Patron patron)
    {
        return !string.IsNullOrEmpty(patron.Name) 
               && patron.Name.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }
}
