namespace Tarifas.Domain;

public record TarifaMonto
{
    public double Value { get; private set; }
    private TarifaMonto() { }
    public TarifaMonto(double value)
    {
        if (!Double.IsPositive(value))
        {
            //Todo: cambiar exception
            throw new Exception("El Monto tiene que ser Positivo");
        }
        Value = value;
    }
}