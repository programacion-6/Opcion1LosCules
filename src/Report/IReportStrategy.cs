namespace Opcion1LosCules
{
    public interface IReportStrategy
    {
        List<object> GenerateReport(BooksManager booksManager, PatronsManager patronsManager);
    }
}
