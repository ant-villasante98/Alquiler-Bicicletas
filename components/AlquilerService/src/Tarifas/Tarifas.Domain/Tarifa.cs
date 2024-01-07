namespace Tarifas.Domain;
public class Tarifa
{

    public TarifaId Id { get; init; }
    public int TipoTarifa { get; private set; }
    public char Definicion { get; private set; }
    public TarifaDiaSemana DiaSemana { get; private set; }
    public TarifaFecha Fecha { get; private set; }
    public TarifaMonto MontoFijoAlquiler { get; private set; }
    public TarifaMonto MontoMinutoFraccion { get; private set; }
    public TarifaMonto MontoKm { get; private set; }
    public TarifaMonto MontoHora { get; private set; }

    private Tarifa() { }
    public Tarifa(TarifaId id, int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora)
    {
        Id = id;
        TipoTarifa = tipoTarifa;
        Definicion = definicion;
        DiaSemana = diaSemana;
        Fecha = fecha;
        MontoFijoAlquiler = montoFijoAlquiler;
        MontoMinutoFraccion = montoMinutoFraccion;
        MontoKm = montoKm;
        MontoHora = montoHora;
    }

    public static Tarifa Create(int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora)
    {
        return new Tarifa()
        {
            TipoTarifa = tipoTarifa,
            Definicion = definicion,
            DiaSemana = diaSemana,
            Fecha = fecha,
            MontoFijoAlquiler = montoFijoAlquiler,
            MontoMinutoFraccion = montoMinutoFraccion,
            MontoKm = montoKm,
            MontoHora = montoHora
        };

    }

    public void Update(int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora)
    {

        TipoTarifa = tipoTarifa;
        Definicion = definicion;
        DiaSemana = diaSemana;
        Fecha = fecha;
        MontoFijoAlquiler = montoFijoAlquiler;
        MontoMinutoFraccion = montoMinutoFraccion;
        MontoKm = montoKm;
        MontoHora = montoHora;
    }
}
