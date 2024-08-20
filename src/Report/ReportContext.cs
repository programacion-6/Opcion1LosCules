namespace Opcion1LosCules;
public class ReportContext
{
    private IReportStrategy _reportStrategy;

    public ReportContext(IReportStrategy reportStrategy)
    {
        _reportStrategy = reportStrategy;
    }

    public List<object> GenerateReport(BooksManager booksManager, PatronsManager patronsManager)
    {
        return _reportStrategy.GenerateReport(booksManager, patronsManager);
    }
}
