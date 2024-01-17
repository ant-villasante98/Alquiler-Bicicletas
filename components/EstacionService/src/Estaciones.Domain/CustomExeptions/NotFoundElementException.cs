
namespace Estaciones.Domain.CustomExeptions;

public class NotFoundElementException : Exception
{
    public NotFoundElementException() { }
    public NotFoundElementException(string message) : base(message)
    { }
    public NotFoundElementException(string message, Exception inner) : base(message, inner)
    { }
}