namespace Opcion1LosCules;

using System.Collections.Generic;
using System.Linq;

public class PatronsManager : AManager<Patron>
{
    private readonly List<Patron> _patrons;
    private readonly PatronValidator _patronValidator;

    private readonly IStorage<Patron> _patronStorage;

    public PatronsManager(IStorage<Patron> patronStorage)
    {
        _patrons = new List<Patron>();
        _patronValidator = new PatronValidator();
        _patronStorage = patronStorage;
        LoadPatronsFromDB();
    }

    public void AddPatron(Patron patron)
    {
        _patronValidator.Validate(patron);
        if (!_patrons.Contains(patron))
        {
            _patrons.Add(patron);
            SavePatronsToDB();
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
            existingPatron.BorrowedBooks = patron.BorrowedBooks;
            existingPatron.BorrowedBooks = patron.BorrowedBooks;
            existingPatron.HistoryBorrowedBooks = patron.HistoryBorrowedBooks;
            SavePatronsToDB();
        }
    }

    public void RemovePatron(Patron patron)
    {
        if (_patrons.Contains(patron))
        {
            _patrons.Remove(patron);
            SavePatronsToDB();
        }
    }
    public List<Patron> GetAllPatrons()
    {
        return _patrons;
    }

   private void LoadPatronsFromDB()
    {
        var patronsFromJson = _patronStorage.Load();
        if (patronsFromJson != null)
        {
            _patrons.AddRange(patronsFromJson);
        }
    }

    private void SavePatronsToDB()
    {
        _patronStorage.Save(_patrons);
    }
}
