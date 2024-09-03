namespace Opcion1LosCules;

public class AvailabilityValidation : IValidation<Book>
{
    public string ErrorMessage => "Book must be available.";

    public bool IsValid(Book book)
    {
        return book.BorrowingInfo.IsAvailable();
    }
}
