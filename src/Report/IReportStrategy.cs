namespace Opcion1LosCules
{
    public interface IReportStrategy
    {
        Task<List<object>> GenerateReport(PatronsManager patronsManager);
    }
}
