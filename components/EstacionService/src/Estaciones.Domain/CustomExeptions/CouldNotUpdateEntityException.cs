namespace Estaciones.Domain.CustomExeptions;

public class CouldNotUpdateDBException : Exception
{

  public CouldNotUpdateDBException() { }

  public CouldNotUpdateDBException(string message)
    : base(message)
  { }

  public CouldNotUpdateDBException(string message, Exception inner)
    : base(message, inner)
  { }
}

