
namespace Opcion1LosCules
{
    public class OverdueBooksReport : IReportStrategy
    {
        public async Task<List<object>> GenerateReport(PatronsManager patronsManager)
        {
            var patrons = (await patronsManager.GetAllPatrons()).ToList();

            return patrons
                .SelectMany(p => p.BorrowedBooks, (p, b) => new { Patron = p, Book = b })
                .Where(pb => pb.Book.DueDate.HasValue && !pb.Book.ReturnDate.HasValue)
                .Select(pb => new { pb.Book.Title, pb.Patron.Name, pb.Book.DueDate })
                .Cast<object>()
                .ToList();
        }
    }
}
