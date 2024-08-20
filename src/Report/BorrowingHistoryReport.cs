namespace Opcion1LosCules;

public class BorrowingHistoryReport : IReportStrategy
{
    private readonly Patron _patron;
    private const int DaysBeforeDueDate = -14;

    public BorrowingHistoryReport(Patron patron)
    {
        _patron = patron;
    }

    public List<object> GenerateReport(BooksManager booksManager, PatronsManager patronsManager)
    {
        var report = new List<object>();

        foreach (var book in _patron.BorrowedBooks)
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

        return report;
    }
}


