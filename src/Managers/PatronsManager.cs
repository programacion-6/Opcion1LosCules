namespace Opcion1LosCules
{
    public class PatronsManager : AManager<Patron>
    {
        private readonly Validator<Patron> _validator;

        public PatronsManager(IStorage<Patron> patronStorage)
            : base(patronStorage, new Validator<Patron>(CreatePatronValidations().ToList()))
        {
            _validator = new Validator<Patron>(CreatePatronValidations().ToList());
        }

        private static IEnumerable<IValidation<Patron>> CreatePatronValidations()
        {
            return new List<IValidation<Patron>>
            {
                new PatronNameValidation(),
                new MembershipNumberValidation(),
                new ContactDetailsValidation(),
                new NoOverdueBooksValidation()
            };
        }

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
                existingPatron.HistoryBorrowedBooks = patron.HistoryBorrowedBooks;
                SaveItemsToDB();
            }
        }
    }
}
