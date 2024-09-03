namespace Opcion1LosCules;

public class CurrentlyBorrowedBooksReport : IReportStrategy
{
    public async Task<List<object>> GenerateReport(PatronsManager patronsManager)
    {
        var patrons = (await patronsManager.GetAll()).ToList();
        return patrons
            .SelectMany(p => p.BorrowedBooks, (p, b) => new { Patron = p, Book = b })
            .Where(pb =>
                pb.Book.BorrowingInfo.DueDate.HasValue && !pb.Book.BorrowingInfo.ReturnDate.HasValue
            )
            .Select(pb => new
            {
                pb.Book.Title,
                pb.Patron.Name,
                pb.Book.BorrowingInfo.DueDate
            })
            .Cast<object>()
            .ToList();
    }
}
