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

    public List<object> GenerateReport(BooksManager booksManager, PatronsManager patronsManager)
    {
        foreach (var book in _patron.HistoryBorrowedBooks)
        {
            report.Add(
                new
                {
                    Title = book.Title,
                    Author = book.Author,
                    ISBN = book.ISBN,
                    Genre = book.Genre,
                    BorrowedOn = book.BorrowingInfo.DueDate.HasValue
                        ? book.BorrowingInfo.DueDate.Value.AddDays(DaysBeforeDueDate)
                        : (DateTime?)null,
                    DueDate = book.BorrowingInfo.DueDate
                }
            );
        }

        return report;
    }
}
