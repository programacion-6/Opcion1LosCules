namespace Opcion1LosCules;

public class MembershipNumberValidation : IValidation<Patron>
{
    public string ErrorMessage => "Membership number must be a positive integer.";

    public bool IsValid(Patron patron)
    {
        return patron.MembershipNumber > 0;
    }
}
