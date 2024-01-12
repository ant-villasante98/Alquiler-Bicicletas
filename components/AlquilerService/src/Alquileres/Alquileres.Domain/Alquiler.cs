using Alquileres.Domain.Estacion;
using Tarifas.Domain;

namespace Alquileres.Domain;
public class Alquiler
{
    public AlquilerId Id { get; init; }
    public AlquilerEstado Estado { get; private set; }
    public string Cliente { get; private set; }
    public AlquilerEstacionId EstacionRetiro { get; private set; }
    public AlquilerEstacionId? EstacionDevolucion { get; private set; }
    public DateTime FechaHoraRetiro { get; private set; }
    public DateTime? FechaHoraDevolucion { get; private set; }
    public AlquilerMonto? Monto { get; private set; }
    public TarifaId TarifaId { get; private set; }

    public virtual Tarifa Tarifa { get; init; } = null!;

    private Alquiler() { }

    public Alquiler(AlquilerId id, AlquilerEstado estado, string cliente, AlquilerEstacionId estacionRetiro, AlquilerEstacionId? estacionDevolucion, DateTime fechaHoraRetiro, DateTime? fechaHoraDevolucion, AlquilerMonto? monto, TarifaId tarifaId)
    {
        Id = id;
        Estado = estado;
        Cliente = cliente;
        EstacionRetiro = estacionRetiro;
        EstacionDevolucion = estacionDevolucion;
        FechaHoraRetiro = fechaHoraRetiro;
        FechaHoraDevolucion = fechaHoraDevolucion;
        Monto = monto;
        TarifaId = tarifaId;
    }

    public static Alquiler StartAlquiler(string cliente, AlquilerEstacionId estacionRetiro)
    {
        //Inicializar fecha
        DateTime dateStartAlquiler = DateTime.UtcNow;
        long startTArifa = (long)dateStartAlquiler.DayOfWeek;
        return new Alquiler()
        {
            Cliente = cliente,
            Estado = AlquilerEstado.Inicio,
            EstacionRetiro = estacionRetiro,
            FechaHoraRetiro = dateStartAlquiler,
            TarifaId = new TarifaId(startTArifa == 0 ? 7 : startTArifa)
        };
    }

    public void SetSpecialTarifa(TarifaId tarifaId)
    {
        TarifaId = tarifaId;
    }
    public void Finish(AlquilerEstacionId estacionDevolucionId, EstacionDistancia estacionDistancia)
    {
        DateTime fechaHoraDevolucion = DateTime.UtcNow;
        FechaHoraDevolucion = fechaHoraDevolucion;
        EstacionDevolucion = estacionDevolucionId;
        Monto = new AlquilerMonto(CalculateAmount(estacionDistancia.Value));
        Estado = AlquilerEstado.Finalizado; ;
    }

    private double CalculateAmount(double distanciaKm)
    {
        DateTime fechaDevolucion = FechaHoraDevolucion ?? throw new Exception("La fecha de devolucion de null");
        TimeSpan tiempoAlquilado = fechaDevolucion - FechaHoraRetiro;
        double montoHora = tiempoAlquilado.Hours * Tarifa.MontoHora.Value;
        double montoKm = distanciaKm * Tarifa.MontoKm.Value;
        double montoFraccion = 0;
        if (tiempoAlquilado.Minutes >= 31)
        {
            montoFraccion += tiempoAlquilado.Minutes * Tarifa.MontoMinutoFraccion.Value;
        }

        double montoTotal = Tarifa.MontoFijoAlquiler.Value + montoHora + montoKm + montoFraccion;
        return montoTotal;

    }
}
