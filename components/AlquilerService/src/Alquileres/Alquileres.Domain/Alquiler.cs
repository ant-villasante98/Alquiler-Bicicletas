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
    public AlquilerFechaRetiro FechaHoraRetiro { get; private set; }
    public AlquilerFechaDevolucion? FechaHoraDevolucion { get; private set; }
    public AlquilerMonto? Monto { get; private set; }
    public TarifaId TarifaId { get; private set; }

    public virtual Tarifa Tarifa { get; init; } = null!;

    private Alquiler() { }

    public Alquiler(AlquilerId id, AlquilerEstado estado, string cliente, AlquilerEstacionId estacionRetiro, AlquilerEstacionId? estacionDevolucion, AlquilerFechaRetiro fechaHoraRetiro, AlquilerFechaDevolucion? fechaHoraDevolucion, AlquilerMonto? monto, TarifaId tarifaId, Tarifa tarifa)
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
        Tarifa = tarifa;
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
            FechaHoraRetiro = new AlquilerFechaRetiro(dateStartAlquiler),
            TarifaId = new TarifaId(startTArifa == 0 ? 7 : startTArifa)
        };
    }

    public void SetSpecialTarifa(TarifaId tarifaId)
    {
        TarifaId = tarifaId;
    }
    public void Finish(AlquilerEstacionId estacionDevolucionId)
    {
        DateTime fechaHoraDevolucion = DateTime.UtcNow;
        FechaHoraDevolucion = new AlquilerFechaDevolucion(fechaHoraDevolucion);
        EstacionDevolucion = estacionDevolucionId;
        Estado = AlquilerEstado.Finalizado; ;
    }
    public void SetAlquilerMonto(AlquilerMonto montoTotal)
    {
        Monto = montoTotal;
    }
}
