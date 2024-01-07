
using System.Data.Common;

namespace Alquileres.Domain;

public record AlquilerMonto
{
    public double Value { get; init; }
    private AlquilerMonto() { }

    public AlquilerMonto(double value)
    {
        if (value < 0)
        {
            // TODO: Cambiar Exception
            throw new Exception("Valor de monto negativo");
        }
        Value = value;
    }
}