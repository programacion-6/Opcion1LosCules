public abstract class Validator<T>
{
    protected Dictionary<string, Func<T, bool>> Validations { get; }

    protected Validator()
    {
        Validations =  new Dictionary<string, Func<T, bool>>();
        InitializeValidations();
    }

    protected abstract void InitializeValidations();

    public bool Validate(T item)
    {
        foreach (var validation in Validations)
        {
            if (!validation.Value(item))
            {
                throw new ValidationException(validation.Key);
            }
        }
        return true;
    }
}