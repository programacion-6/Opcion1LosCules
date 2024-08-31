using Opcion1LosCules;

public class BookValidator : Validator<Book>
{
    protected override void InitializeValidations()
    {
        Validations.Add("Title is required.", book => !string.IsNullOrEmpty(book.Title));
        Validations.Add("Author is required and must only contain alphabetic characters.", 
            book => !string.IsNullOrEmpty(book.Author) && book.Author.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)));

        Validations.Add("ISBN is required.", book => !string.IsNullOrEmpty(book.ISBN));

        Validations.Add("Genre is required and must only contain alphabetic characters.", 
            book => !string.IsNullOrEmpty(book.Genre) && book.Genre.All(c => char.IsLetter(c) || char.IsWhiteSpace(c)));
        Validations.Add("Publication year must be positive.", book => book.PublicationYear > 0);
        Validations.Add("Book must be available.", book => book.BorrowingInfo.IsAvailable());
    }
}