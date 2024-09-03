namespace Opcion1LosCules;

public class ISBNValidation : IValidation<Book>
{
    public string ErrorMessage => "ISBN is required.";

    public bool IsValid(Book book)
    {
        return !string.IsNullOrEmpty(book.ISBN);
    }
}
