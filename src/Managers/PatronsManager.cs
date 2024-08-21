namespace Opcion1LosCules;
public class PatronsManager
{
    private readonly List<Patron> _patrons;
    private readonly PatronValidator _patronValidator;


    public PatronsManager()
    {
        _patrons = new List<Patron>();
        _patronValidator = new PatronValidator();
    }


    public void AddPatron(Patron patron)
    {
        _patronValidator.Validate(patron);
        if (!_patrons.Contains(patron))
        {
            _patrons.Add(patron);
        }
    }

    public void UpdatePatron(Patron patron)
    {
        _patronValidator.Validate(patron);
        var existingPatron = _patrons.FirstOrDefault(p => p.MembershipNumber == patron.MembershipNumber);

        if (existingPatron != null)
        {
            existingPatron.Name = patron.Name;
            existingPatron.MembershipNumber = patron.MembershipNumber;
            existingPatron.ContactDetails = patron.ContactDetails;
        }
    }

    public void RemovePatron(Patron patron)
    {
        if (_patrons.Contains(patron))
        {
            _patrons.Remove(patron);
        }
    }
    public List<Patron> GetAllPatrons()
    {
        return _patrons;
    }
}
