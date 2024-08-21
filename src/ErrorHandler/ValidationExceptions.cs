public class ValidationException : Exception
{
    public ValidationException() { }

    public ValidationException(string message)
        : base($"Validation Error: {message}") { }

    public ValidationException(string message, Exception inner)
        : base($"Validation Error: {message}", inner) { }
}