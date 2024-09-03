namespace Opcion1LosCules;
public interface IValidation<T>
{
    string ErrorMessage { get; }
    bool IsValid(T item);
}
