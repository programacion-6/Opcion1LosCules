namespace Opcion1LosCules;
    public class Database
    {
        public List<Book> Books { get; private set; }
        public List<Patron> Patrons { get; private set; }
        public List<BorrowingOperation> BorrowingOperations { get; private set; }

        public Database()
        {
            InitializeBooks();
            InitializePatrons();
            InitializeBorrowingOperations();
        }

        private void InitializeBooks()
        {
            Books = new List<Book>
            {
                new Book("The Great Gatsby", "F. Scott Fitzgerald", "9780743273565", "Fiction", 1925),
                new Book("1984", "George Orwell", "9780451524935", "Dystopian", 1949),
                new Book("To Kill a Mockingbird", "Harper Lee", "9780061120084", "Fiction", 1960),
                new Book("Pride and Prejudice", "Jane Austen", "9780141439518", "Romance", 1813),
                new Book("The Catcher in the Rye", "J.D. Salinger", "9780316769488", "Fiction", 1951),
                new Book("The Hobbit", "J.R.R. Tolkien", "9780345339683", "Fantasy", 1937),
                new Book("Moby Dick", "Herman Melville", "9781503280786", "Adventure", 1851),
                new Book("War and Peace", "Leo Tolstoy", "9781400079988", "Historical Fiction", 1869),
                new Book("Brave New World", "Aldous Huxley", "9780060850524", "Dystopian", 1932),
                new Book("Crime and Punishment", "Fyodor Dostoevsky", "9780486415871", "Psychological Fiction", 1866)
            };
        }

        private void InitializePatrons()
        {
            Patrons = new List<Patron>
            {
                new Patron("Alice Smith", 1, "alice@example.com"),
                new Patron("Bob Johnson", 2, "bob@example.com"),
                new Patron("Charlie Brown", 3, "charlie@example.com"),
                new Patron("David Wilson", 4, "david@example.com"),
                new Patron("Eve Davis", 5, "eve@example.com"),
                new Patron("Frank Miller", 6, "frank@example.com"),
                new Patron("Grace Lee", 7, "grace@example.com"),
                new Patron("Hannah Moore", 8, "hannah@example.com"),
                new Patron("Ian Taylor", 9, "ian@example.com"),
                new Patron("Judy Anderson", 10, "judy@example.com")
            };
        }

        private void InitializeBorrowingOperations()
        {
            BorrowingOperations = new List<BorrowingOperation>
            {
                CreateBorrowingOperation(Patrons[0], Books[0], DateTime.Now.AddDays(-15)),
                CreateBorrowingOperation(Patrons[0], Books[1], DateTime.Now.AddDays(-10)),
                CreateBorrowingOperation(Patrons[1], Books[2], DateTime.Now.AddDays(-5)),
                CreateBorrowingOperation(Patrons[1], Books[3], DateTime.Now.AddDays(-20)),
                CreateBorrowingOperation(Patrons[2], Books[4], DateTime.Now.AddDays(-25)),
                CreateBorrowingOperation(Patrons[3], Books[5], DateTime.Now.AddDays(-8)),
                CreateBorrowingOperation(Patrons[3], Books[6], DateTime.Now.AddDays(-30)),
                CreateBorrowingOperation(Patrons[4], Books[7], DateTime.Now.AddDays(-12)),
                CreateBorrowingOperation(Patrons[5], Books[8], DateTime.Now.AddDays(-7)),
                CreateBorrowingOperation(Patrons[6], Books[9], DateTime.Now.AddDays(-22))
            };
        }

        private BorrowingOperation CreateBorrowingOperation(Patron patron, Book book, DateTime date)
        {
            if (book.IsAvailable())
            {
                var borrowingOperation = new BorrowBook();
                borrowingOperation.SetPatron(patron);
                borrowingOperation.SetBook(book);
                borrowingOperation.SetDate(date);
                return borrowingOperation;
            }

            var returnOperation = new ReturnBook();
            returnOperation.SetPatron(patron);
            returnOperation.SetBook(book);
            returnOperation.SetDate(date);
            return returnOperation;
        }
    }

