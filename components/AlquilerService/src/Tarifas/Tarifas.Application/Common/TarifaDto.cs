
namespace Tarifas.Application.Common;

public class TarifaDto
{

    public long Id { get; init; }
    public int TipoTarifa { get; init; }
    public char Definicion { get; init; }
    public int? DiaSemana { get; init; }
    public int? DiaMes { get; init; }
    public int? Mes { get; init; }
    public int? Anio { get; init; }
    public double MontoFijoAlquiler { get; private set; }
    public double MontoMinutoFraccion { get; private set; }
    public double MontoKm { get; private set; }
    public double MontoHora { get; private set; }

    private TarifaDto() { }
    public TarifaDto(long id, int tipoTarifa, char definicion, int? diaSemana, int? diaMes, int? mes, int? anio, double montoFijoAlquiler, double montoMinutoFraccion, double montoKm, double montoHora)
    {
        Id = id;
        TipoTarifa = tipoTarifa;
        Definicion = definicion;
        DiaSemana = diaSemana;
        DiaMes = diaMes;
        Mes = mes;
        Anio = anio;
        MontoFijoAlquiler = montoFijoAlquiler;
        MontoMinutoFraccion = montoMinutoFraccion;
        MontoKm = montoKm;
        MontoHora = montoHora;
    }

}