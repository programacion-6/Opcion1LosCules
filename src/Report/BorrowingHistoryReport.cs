namespace Opcion1LosCules;

public class BorrowingHistoryReport : IReportStrategy
{
    private readonly Patron _patron;
    private const int DaysBeforeDueDate = -14;
    private List<object> report = new List<object>();

    public BorrowingHistoryReport(Patron patron)
    {
        _patron = patron;
    }

    public Task<List<object>> GenerateReport(PatronsManager patronsManager)
    {
        foreach (var book in _patron.HistoryBorrowedBooks)
        {
            report.Add(new
            {
                Title = book.Title,
                Author = book.Author,
                ISBN = book.ISBN,
                Genre = book.Genre,
                BorrowedOn = book.DueDate.HasValue ? book.DueDate.Value.AddDays(DaysBeforeDueDate) : (DateTime?)null,
                DueDate = book.DueDate
            });
        }

        return Task.FromResult(report);
    }
}


