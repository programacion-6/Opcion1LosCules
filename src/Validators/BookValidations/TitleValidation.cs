namespace Opcion1LosCules;
public class TitleValidation : IValidation<Book>
{
    public string ErrorMessage => "Title is required and must contain valid alphabetic or numeric characters.";

    public bool IsValid(Book book)
    {
        return !string.IsNullOrEmpty(book.Title) 
               && book.Title.Any(char.IsLetter)
               && book.Title.Any(char.IsLetterOrDigit)
               && book.Title.All(c => char.IsLetterOrDigit(c) || char.IsWhiteSpace(c) || c == '-');
    }
}
