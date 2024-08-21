namespace Opcion1LosCules
{
    public class PatronsManagementMenu
    {
        private Library _library;
        private IPatronSearchStrategy _patronSearchStrategy;

        public PatronsManagementMenu(Library library) 
        {
            _library = library;
        }

        public void AddPatron()
        {
            Console.Write("Enter patron name: ");
            string name = Console.ReadLine();

            Console.Write("Enter patron membership number: ");
            int membershipNumber;
            while (!int.TryParse(Console.ReadLine(), out membershipNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
            Console.Write("Enter patron contact details (email): ");
            string contactDetails = Console.ReadLine();

            Patron patron = new Patron(name,membershipNumber,contactDetails);
         

            _library.patronsManager().AddPatron(patron);
            Console.WriteLine("Patron added successfully.");
        }

        public void UpdatePatron()
        {
            Console.Write("Enter the membership number of the patron to update: ");
            int membershipNumber;
            while (!int.TryParse(Console.ReadLine(), out membershipNumber))
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }

            var existingPatron = _library.patronsManager().GetAllPatrons()
                .FirstOrDefault(p => p.MembershipNumber == membershipNumber);

            if (existingPatron == null)
            {
                Console.WriteLine("No patron found with that membership number. Please try again.");
                return;
            }

            Console.Write("Enter new patron name: ");
            string name = Console.ReadLine();

            Console.Write("Enter new contact details (email): ");
            string contactDetails = Console.ReadLine();

            Patron updatedPatron = new Patron(name, membershipNumber, contactDetails);

            _library.patronsManager().UpdatePatron(updatedPatron);
            Console.WriteLine("Patron updated successfully.");
        }



        public void RemovePatron()
        {
            Console.Write("Enter the membership number of the patron to remove: ");
            int membershipNumber;
            while (!int.TryParse(Console.ReadLine(), out membershipNumber))
        {
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

             Patron patron = _library.patronsManager().GetAllPatrons()
                .FirstOrDefault(p => p.MembershipNumber == membershipNumber);


            if (patron != null)
            {
                _library.patronsManager().RemovePatron(patron);
                Console.WriteLine("Patron removed successfully.");
            }
            else
            {
                Console.WriteLine("Patron not found.");
            }
        }
    }
}
