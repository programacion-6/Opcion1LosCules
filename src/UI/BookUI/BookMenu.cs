namespace Opcion1LosCules
{
    public class BookMenu 
    {
        private BooksManagementMenu _bookManagement;
        private Library _library;
        
        public BookMenu(Library library) 
        {
            _library = library;
            _bookManagement = new BooksManagementMenu(_library);
        }

        public void ShowBookMenu()
        {
            while (true)
            {
                Console.WriteLine("Book Menu");
                Console.WriteLine("1. Add Book");
                Console.WriteLine("2. Update Book");
                Console.WriteLine("3. Remove Book");
                Console.WriteLine("0. Exit");
                Console.Write("Select an option: ");
                var option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        _bookManagement.AddBook();
                        break;
                    case "2":
                        _bookManagement.UpdateBook();
                        break;
                    case "3":
                        _bookManagement.RemoveBook();
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
