namespace Opcion1LosCules
{
    public class HomePage
    {

        private BookMenu _bookMenu;
        private PatronMenu _patronMenu;

        private PatronBorrowMenu _patronBorrowMenu;
        private Library _library;
        BookSearchMenu bookSearchMenu;
        PatronSearchMenu patronSearchMenu;

        public HomePage()
        {
            _library = new Library();
            _patronBorrowMenu = new PatronBorrowMenu(_library);
            _patronMenu = new PatronMenu(_library);
            _bookMenu = new BookMenu(_library);
            bookSearchMenu = new BookSearchMenu(_library.booksManager());
            patronSearchMenu = new PatronSearchMenu(_library.patronsManager());
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
                        _bookMenu.ShowBookMenu();
                        break;
                    case "2":
                        _patronMenu.showPatronMenu();
                        break;
                    case "3":
                        _patronBorrowMenu.BorrowBook();
                        break;
                    case "4":
                        _patronBorrowMenu.ReturnBook();
                        break;
                    case "5":
                        bookSearchMenu.DisplaySearchMenu();
                        break;
                    case "6":
                        patronSearchMenu.DisplaySearchMenu();
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
