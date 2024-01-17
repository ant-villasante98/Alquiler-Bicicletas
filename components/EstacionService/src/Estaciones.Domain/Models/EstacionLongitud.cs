
namespace Estaciones.Domain.Models;

public record EstacionLongitud
{
    public double Value { get; init; }

    public EstacionLongitud(double value)
    {
        if (value < -180 || value > 180)
        {
            throw new Exception("El valor de la longitud es invalido");
        }
        Value = value;
    }
}