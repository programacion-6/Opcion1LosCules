using Opcion1LosCules;

public interface IBookRepository
{
    Task AddBook(Book book);
    Task UpdateBook(string id, Book book);
    Task RemoveBook(string id);
    Task<Book> GetBookById(string id);
    Task<IEnumerable<Book>> GetAllBooks();
}