namespace Opcion1LosCules;
public class ValidatorFactory
{
    public static Validator<Book> CreateBookValidator()
    {
        var bookValidations = new List<IValidation<Book>>
        {
            new TitleValidation(),
            new AuthorValidation(),
            new ISBNValidation(),
            new GenreValidation(),
            new PublicationYearValidation(),
            new AvailabilityValidation()
        };

        return new Validator<Book>(bookValidations);
    }

    public static Validator<Patron> CreatePatronValidator()
    {
        var patronValidations = new List<IValidation<Patron>>
        {
            new PatronNameValidation(),
            new MembershipNumberValidation(),
            new ContactDetailsValidation(),
            new NoOverdueBooksValidation()
        };

        return new Validator<Patron>(patronValidations);
    }

    public static Validator<BorrowingOperation> CreateBorrowingSystemValidator()
    {
        var borrowingValidations = new List<IValidation<BorrowingOperation>>
        {
            new PatronRequiredValidation(),
            new BookRequiredValidation(),
            new DateRequiredValidation(),
            new BookAvailableForBorrowingValidation(),
            new PatronDoesNotHaveBookValidation(),
            new BookBorrowedByPatronValidation(),
            new BookNotReturnedValidation()
        };

        return new Validator<BorrowingOperation>(borrowingValidations);
    }
}
