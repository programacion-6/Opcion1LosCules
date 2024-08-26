namespace Opcion1LosCules;

using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class PatronsManager
{
    private readonly List<Patron> _patrons;
    private readonly PatronValidator _patronValidator;

    private readonly string _filePath = "../src/DataBase/Patrons.json";


    public PatronsManager()
    {
        _patrons = new List<Patron>();
        _patronValidator = new PatronValidator();
        LoadPatronsFromDB("../src/DataBase/Patrons.json");
    }


    public void AddPatron(Patron patron)
    {
        _patronValidator.Validate(patron);
        if (!_patrons.Contains(patron))
        {
            _patrons.Add(patron);
            SavePatronsToDB(_filePath);
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
            SavePatronsToDB(_filePath);
        }
    }

    public void RemovePatron(Patron patron)
    {
        if (_patrons.Contains(patron))
        {
            _patrons.Remove(patron);
            SavePatronsToDB(_filePath);
        }
    }
    public List<Patron> GetAllPatrons()
    {
        return _patrons;
    }

    private void LoadPatronsFromDB(string filePath)
    {
        if (File.Exists(filePath))
        {
            var jsonData = File.ReadAllText(filePath);
            var patronsFromJson = JsonConvert.DeserializeObject<List<Patron>>(jsonData);

            if (patronsFromJson != null)
            {
                _patrons.AddRange(patronsFromJson);
            }
        }
        else
        {
            throw new FileNotFoundException($"El archivo {filePath} no fue encontrado.");
        }
    }


    private void SavePatronsToDB(string filePath)
    {
        var jsonData = JsonConvert.SerializeObject(_patrons, Formatting.Indented);
        File.WriteAllText(filePath, jsonData);
    }
}
