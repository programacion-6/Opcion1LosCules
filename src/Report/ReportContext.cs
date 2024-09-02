namespace Opcion1LosCules;
public class ReportContext
{
    private IReportStrategy _reportStrategy;

    public ReportContext(IReportStrategy reportStrategy)
    {
        _reportStrategy = reportStrategy;
    }

    public Task<List<object>> GenerateReport(PatronsManager patronsManager)
    {
        return _reportStrategy.GenerateReport(patronsManager);
    }
}
