namespace Opcion1LosCules
{
    public class OverdueBooksReport : IReportStrategy
    {
        public List<object> GenerateReport(BooksManager booksManager, PatronsManager patronsManager)
        {
            return patronsManager.GetAllPatrons()
                                 .SelectMany(p => p.BorrowedBooks, (p, b) => new { Patron = p, Book = b })
                                 .Where(pb => pb.Book.DueDate.HasValue && pb.Book.DueDate < DateTime.Now && !pb.Book.ReturnDate.HasValue)
                                 .Select(pb => new { pb.Book.Title, pb.Patron.Name, pb.Book.DueDate })
                                 .Cast<object>()
                                 .ToList();
        }
    }
}
