namespace Opcion1LosCules;

public class GenreValidation : IValidation<Book>
{
    public string ErrorMessage => "Genre is required and must only contain alphabetic characters.";

    public bool IsValid(Book book)
    {
        return !string.IsNullOrEmpty(book.Genre) 
               && book.Genre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }
}
