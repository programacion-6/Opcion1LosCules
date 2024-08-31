namespace Opcion1LosCules;

using System.Linq;

public class PatronsManager : AManager<Patron>
{
    public PatronsManager(IStorage<Patron> patronStorage)
        : base(patronStorage, new PatronValidator()) { }

    public override void UpdateItem(Patron patron)
    {
        var existingPatron = Items.FirstOrDefault(p =>
            p.MembershipNumber == patron.MembershipNumber
        );

        if (existingPatron != null)
        {
            existingPatron.Name = patron.Name;
            existingPatron.MembershipNumber = patron.MembershipNumber;
            existingPatron.ContactDetails = patron.ContactDetails;
            existingPatron.BorrowedBooks = patron.BorrowedBooks;
            existingPatron.BorrowedBooks = patron.BorrowedBooks;
            existingPatron.HistoryBorrowedBooks = patron.HistoryBorrowedBooks;
            SaveItemsToDB();
        }
    }
}
