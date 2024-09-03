namespace Opcion1LosCules
{
    public class Library
    {
        private BooksManager _booksManager;
        private PatronsManager _patronsManager;
        private BorrowBook _borrowBook;
        private ReturnBook _returnBook;
        private readonly Validator<Book> _bookValidator;
        private readonly Validator<Patron> _patronValidator;
        private readonly Validator<BorrowingOperation> _borrowingOperationValidator;

        public Library()
        {
            var databaseContext = new Database();

            _bookValidator = ValidatorFactory.CreateBookValidator();
            _patronValidator = ValidatorFactory.CreatePatronValidator();
            _borrowingOperationValidator = ValidatorFactory.CreateBorrowingSystemValidator();


            _booksManager = new BooksManager(databaseContext);
            _patronsManager = new PatronsManager(databaseContext);
            _borrowBook = new BorrowBook(databaseContext);
            _returnBook = new ReturnBook(databaseContext);
        }

        public PatronsManager patronsManager() 
        {
            return _patronsManager;
        }

        public BooksManager booksManager() 
        {
            return _booksManager; 
        }

        public BorrowBook BorrowBook() 
        {
            return _borrowBook;
        }

        public ReturnBook ReturnBook() 
        {
            return _returnBook;
        }

        public Validator<Book> GetBookValidator()
        {
            return _bookValidator;
        }

        public Validator<Patron> GetPatronValidator()
        {
            return _patronValidator;
        }

        public Validator<BorrowingOperation> GetBorrowingOperationValidator()
        {
            return _borrowingOperationValidator;
        }
    }
}
