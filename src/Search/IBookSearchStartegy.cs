namespace Opcion1LosCules;
public interface IBookSearchStrategy
{
    List<Book> Search(string query, List<Book> books);
}
