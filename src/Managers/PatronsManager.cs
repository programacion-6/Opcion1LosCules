namespace Opcion1LosCules;
public class PatronsManager
{
    private readonly List<Patron> _patrons;

    public PatronsManager()
    {
        _patrons = new List<Patron>();
    }

    public void AddPatron(Patron patron)
    {
        if (!_patrons.Contains(patron))
        {
            _patrons.Add(patron);
        }
    }

    public void UpdatePatron(Patron patron)
    {
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