namespace Opcion1LosCules.Tests
{
    public class BookTests
    {
        [Fact]
        public void Constructor_ShouldCorrectlyInitializeAllProperties()
        {
            string expectedTitle = "The Great Gatsby";
            string expectedAuthor = "F. Scott Fitzgerald";
            string expectedISBN = "123-4567891234";
            string expectedGenre = "Fiction";
            int expectedPublicationYear = 1925;

            Book book = new Book(expectedTitle, expectedAuthor, expectedISBN, expectedGenre, expectedPublicationYear);

            Assert.Equal(expectedTitle, book.Title);
            Assert.Equal(expectedAuthor, book.Author);
            Assert.Equal(expectedISBN, book.ISBN);
            Assert.Equal(expectedGenre, book.Genre);
            Assert.Equal(expectedPublicationYear, book.PublicationYear);
            Assert.False(book.BorrowingInfo.IsBorrowed);
        }

        [Fact]
        public void Properties_ShouldReturnExpectedValues()
        {
            string title = "1984";
            string author = "George Orwell";
            string isbn = "978-0451524935";
            string genre = "Dystopian";
            int publicationYear = 1949;
            bool expectedIsBorrowed = false;

            Book book = new Book(title, author, isbn, genre, publicationYear);

            string actualTitle = book.Title;
            string actualAuthor = book.Author;
            string actualISBN = book.ISBN;
            string actualGenre = book.Genre;
            int actualPublicationYear = book.PublicationYear;
            bool actualIsBorrowed = book.BorrowingInfo.IsBorrowed;

            Assert.Equal(title, actualTitle);
            Assert.Equal(author, actualAuthor);
            Assert.Equal(isbn, actualISBN);
            Assert.Equal(genre, actualGenre);
            Assert.Equal(publicationYear, actualPublicationYear);
            Assert.Equal(expectedIsBorrowed, actualIsBorrowed);
        }

        [Fact]
        public void BorrowedStatus_ShouldChangeWhenBookIsBorrowed()
        {
            Book book = new Book("Moby Dick", "Herman Melville", "978-0142437247", "Adventure", 1851);

            book.BorrowingInfo.IsBorrowed = true;

            Assert.True(book.BorrowingInfo.IsBorrowed);
        }

        [Fact]
        public void MarkAsBorrowed_ShouldSetCorrectDueDate()
        {
            Book book = new Book("The Hobbit", "J.R.R. Tolkien", "978-0345339683", "Fantasy", 1937);
            DateTime borrowDate = new DateTime(2024, 8, 24);

            book.BorrowingInfo.MarkAsBorrowed(borrowDate);

            Assert.Equal(borrowDate.AddDays(14), book.BorrowingInfo.DueDate);
            Assert.Null(book.BorrowingInfo.ReturnDate);
        }

        [Fact]
        public void MarkAsReturned_ShouldResetDueDateAndSetReturnDate()
        {
            Book book = new Book("To Kill a Mockingbird", "Harper Lee", "978-0061120084", "Fiction", 1960);
            DateTime returnDate = new DateTime(2024, 9, 7);

            book.BorrowingInfo.MarkAsReturned(returnDate);

            Assert.Null(book.BorrowingInfo.DueDate);
            Assert.Equal(returnDate, book.BorrowingInfo.ReturnDate);
        }

        [Fact]
        public void IsAvailable_ShouldReturnTrue_WhenBookIsNotBorrowedOrPastDueDate()
        {
            Book book = new Book("Pride and Prejudice", "Jane Austen", "978-0141439518", "Romance", 1813);

            Assert.True(book.BorrowingInfo.IsAvailable());

            book.BorrowingInfo.MarkAsBorrowed(DateTime.Now.AddDays(-16)); 
            
            Assert.True(book.BorrowingInfo.IsAvailable()); 
        }
    }

}
