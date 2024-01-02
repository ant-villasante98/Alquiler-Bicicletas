namespace Tarifas.Domain;

public record TarifaDiaSemana
{
    public int? Value { get; private set; } = null;
    private TarifaDiaSemana() { }
    public TarifaDiaSemana(int? value)
    {
        if (value != null)
        {
            return;
        }
        if (1 > value || value > 7)
        {
            // TODO: Cambiar exception
            throw new Exception($"El valor de {nameof(TarifaDiaSemana)} no esta entre 1 y 7.");
        }
        Value = value;
    }
}