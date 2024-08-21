namespace Opcion1LosCules
{
    public class HomePage
    {

        private BookMenu _bookMenu;
        private PatronMenu _patronMenu;

        private PatronBorrowMenu _patronBorrowMenu;
        private Library _library;

        public HomePage(Library library)
        {
            _patronBorrowMenu = new PatronBorrowMenu(library);
        }

        public void DisplayMenu()
        {
            while (true)
            {
                Console.WriteLine("Library Management System");
                Console.WriteLine("1. Manage Books");
                Console.WriteLine("2. Manage Patrons");
                Console.WriteLine("3. Borrow Books");
                Console.WriteLine("4. Return Books");
                Console.WriteLine("5. Search Books");
                Console.WriteLine("6. Search Patrons");
                Console.WriteLine("7. Generate Reports");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":

                        break;
                    case "2":

                        break;
                    case "3":
                        _patronBorrowMenu.BorrowBook();
                        break;
                    case "4":
                        _patronBorrowMenu.ReturnBook();
                        break;
                    case "5":

                        break;
                    case "6":

                        break;
                    case "7":

                        break;
                    case "0":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }
    }
}
