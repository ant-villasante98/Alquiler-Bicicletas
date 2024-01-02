
namespace Tarifas.Domain;

public record TarifaFecha
{
    public int? Dia { get; private set; } = null;
    public int? Mes { get; private set; } = null;
    public int? Anio { get; private set; } = null;

    private TarifaFecha() { }
    public TarifaFecha(int? dia, int? mes, int? anio)
    {
        if (dia == null && mes == null & anio == null)
        {
            return;
        }
        if (dia < 1 || dia > 31 || mes < 1 && mes > 12)
        {
            //TODO: cambiar la exception
            throw new Exception("La fecha no es correcta");
        }
        Dia = dia;
        Mes = mes;
        Anio = anio;

    }

};