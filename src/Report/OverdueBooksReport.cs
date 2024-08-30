namespace Opcion1LosCules
{
    public class OverdueBooksReport : IReportStrategy
    {
        public List<object> GenerateReport(BooksManager booksManager, PatronsManager patronsManager)
        {
            return patronsManager
                .GetAllPatrons()
                .SelectMany(p => p.BorrowedBooks, (p, b) => new { Patron = p, Book = b })
                .Where(pb =>
                    pb.Book.BorrowingInfo.DueDate.HasValue
                    && pb.Book.BorrowingInfo.DueDate < DateTime.Now
                    && !pb.Book.BorrowingInfo.ReturnDate.HasValue
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
}
