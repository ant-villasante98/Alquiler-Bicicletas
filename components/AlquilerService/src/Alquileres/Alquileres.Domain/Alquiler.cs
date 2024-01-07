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

}
