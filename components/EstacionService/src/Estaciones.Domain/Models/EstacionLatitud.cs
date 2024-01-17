
namespace Estaciones.Domain.Models;

public record EstacionLatitud
{
    public double Value { get; init; }
    public EstacionLatitud(double value)
    {
        if (value < -90 || value > 90)
        {
            throw new Exception("Error de validacion de longitud");
        }
        Value = value;
    }
}