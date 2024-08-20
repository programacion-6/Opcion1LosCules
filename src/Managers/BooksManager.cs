namespace Opcion1LosCules;

public class BooksManager
{
    private readonly List<Book> _books;
    public BooksManager()
    {
        _books = [];
    }

    public void AddBook(Book book)
    {
        if (!_books.Contains(book))
        {
            _books.Add(book);
        }
    }

    public void UpdateBook(Book book)
    {
        var existingBook = _books.FirstOrDefault(b => b.Title == book.Title);
        
        if (existingBook != null)
        {
            existingBook.Author = book.Author;
            existingBook.ISBN = book.ISBN;
            existingBook.Genre = book.Genre;
            existingBook.PublicationYear = book.PublicationYear;
        }
    }

    public void RemoveBook(Book book)
    {
        if (_books.Contains(book))
        {
            _books.Remove(book);
        }
    }
}