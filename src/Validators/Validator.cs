namespace Opcion1LosCules;
public class Validator<T>
{
    private readonly List<IValidation<T>> _validations;

    public Validator(List<IValidation<T>> validations)
    {
        _validations = validations;
    }

    public bool Validate(T item)
    {
        foreach (var validation in _validations)
        {
            if (!validation.IsValid(item))
            {
                throw new ValidationException(validation.ErrorMessage);
            }
        }
        return true;
    }
}
