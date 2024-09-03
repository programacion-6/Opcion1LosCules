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
            var bookStorage = new FileStorage<Book>("DataBase/BookStorage.json");
            var patronStorage = new FileStorage<Patron>("DataBase/Patrons.json");

            _bookValidator = ValidatorFactory.CreateBookValidator();
            _patronValidator = ValidatorFactory.CreatePatronValidator();
            _borrowingOperationValidator = ValidatorFactory.CreateBorrowingSystemValidator();


            _booksManager = new BooksManager(bookStorage);
            _patronsManager = new PatronsManager(patronStorage);
            _borrowBook = new BorrowBook(bookStorage, patronStorage);
            _returnBook = new ReturnBook(bookStorage, patronStorage);
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
