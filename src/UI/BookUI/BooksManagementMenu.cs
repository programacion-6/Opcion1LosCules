namespace Opcion1LosCules
{
    public class BooksManagementMenu
    {
        private Library _library;

        public BooksManagementMenu(Library library)
        {
            _library = library;
        }

        public void AddBook()
        {
            Console.Write("Enter book title: ");
            string title = Console.ReadLine();

            Console.Write("Enter book author: ");
            string author = Console.ReadLine();

            Console.Write("Enter book ISBN: ");
            string ISBN = Console.ReadLine();

            Console.Write("Enter book genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter book publication year: ");
            int publicationYear;
            while (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
            }

            Book book = new Book(title, author, ISBN, genre, publicationYear);

            _library.booksManager().AddBook(book);
            Console.WriteLine("Book added successfully.");
        }

        public void UpdateBook()
        {
            Console.Write("Enter the title of the book to update: ");
            string title = Console.ReadLine();

            var existingBook = _library.booksManager().GetAllBooks()
                .FirstOrDefault(b => b.Title == title);

            if (existingBook == null)
            {
                Console.WriteLine("No book found with that title. Please try again.");
                return;
            }

            Console.Write("Enter new book author: ");
            string author = Console.ReadLine();

            Console.Write("Enter new book ISBN: ");
            string ISBN = Console.ReadLine();

            Console.Write("Enter new book genre: ");
            string genre = Console.ReadLine();

            Console.Write("Enter new book publication year: ");
            int publicationYear;
            while (!int.TryParse(Console.ReadLine(), out publicationYear))
            {
                Console.WriteLine("Invalid input. Please enter a valid year.");
            }

            Book updatedBook = new Book(title, author, ISBN, genre, publicationYear);

            _library.booksManager().UpdateBook(updatedBook);
            Console.WriteLine("Book updated successfully.");
        }

        public void RemoveBook()
        {
            Console.Write("Enter the title of the book to remove: ");
            string title = Console.ReadLine();

            var existingBook = _library.booksManager().GetAllBooks()
                .FirstOrDefault(b => b.Title == title);

            if (existingBook != null)
            {
                _library.booksManager().RemoveBook(existingBook);
                Console.WriteLine("Book removed successfully.");
            }
            else
            {
                Console.WriteLine("No book found with that title.");
            }
        }
    }
}
