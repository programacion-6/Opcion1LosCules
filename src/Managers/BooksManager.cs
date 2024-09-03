namespace Opcion1LosCules
{
    public class BooksManager : AManager<Book>
    {
        private readonly Validator<Book> _validator;

        public BooksManager(IStorage<Book> bookStorage)
            : base(bookStorage, new Validator<Book>(CreateBookValidations().ToList()))
        {
            _validator = new Validator<Book>(CreateBookValidations().ToList());
        }

        private static IEnumerable<IValidation<Book>> CreateBookValidations()
        {
            return new List<IValidation<Book>>
            {
                new TitleValidation(),
                new AuthorValidation(),
                new ISBNValidation(),
                new GenreValidation(),
                new PublicationYearValidation(),
                new AvailabilityValidation()
            };
        }

        public override void UpdateItem(Book book)
        {
            var existingBook = Items.FirstOrDefault(b => b.Title == book.Title);

            if (existingBook != null)
            {
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.Genre = book.Genre;
                existingBook.PublicationYear = book.PublicationYear;
                existingBook.BorrowingInfo.DueDate = book.BorrowingInfo.DueDate;
                existingBook.BorrowingInfo.ReturnDate = book.BorrowingInfo.ReturnDate;
                existingBook.BorrowingInfo.IsBorrowed = book.BorrowingInfo.IsBorrowed;
                SaveItemsToDB();
            }
        }
    }
}
