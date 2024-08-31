namespace Opcion1LosCules;

public class BooksManager : AManager<Book>
{
    public BooksManager(IStorage<Book> bookStorage)
        : base(bookStorage, new BookValidator()) { }

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
