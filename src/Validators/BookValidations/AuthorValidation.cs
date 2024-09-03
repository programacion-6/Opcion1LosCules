namespace Opcion1LosCules;

public class AuthorValidation : IValidation<Book>
{
    public string ErrorMessage => "Author is required and must only contain alphabetic characters.";

    public bool IsValid(Book book)
    {
        return !string.IsNullOrEmpty(book.Author) 
               && book.Author.All(c => char.IsLetter(c) || char.IsWhiteSpace(c));
    }
}
