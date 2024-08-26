namespace Opcion1LosCules.Tests
{
    public class BooksManagerTests
    {
        [Fact]
        public void AddBook_ShouldAddValidBook()
        {
            var book = new Book("The Catcher in the Rye", "J.D. Salinger", "45825", "Fiction", 1951);
            var booksManager = new BooksManager();
            booksManager.AddBook(book);

            Assert.Contains(book, booksManager.GetAllBooks());
        }


}
}
