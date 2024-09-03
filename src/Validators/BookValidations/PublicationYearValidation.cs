namespace Opcion1LosCules;

public class PublicationYearValidation : IValidation<Book>
{
    public string ErrorMessage => "Publication year must be positive.";

    public bool IsValid(Book book)
    {
        return book.PublicationYear > 0;
    }
}
