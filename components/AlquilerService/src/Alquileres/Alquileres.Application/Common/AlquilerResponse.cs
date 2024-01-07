
namespace Alquileres.Application.Common;

public class AlquilerResponse
{
    public long Id { get; init; }
    public byte Estado { get; init; }
    public string Cliente { get; init; }
    public long EstacionRetiro { get; init; }
    public long? EstacionDevolucion { get; init; }
    public DateTime FechaHoraRetiro { get; init; }
    public DateTime? FechaHoraDevolucion { get; init; }
    public double? Monto { get; init; }
    public long TarifaId { get; init; }

    private AlquilerResponse() { }

    public AlquilerResponse(long id, byte estado, string cliente, long estacionRetiro, long? estacionDevolucion, DateTime fechaHoraRetiro, DateTime? fechaHoraDevolucion, double? monto, long tarifaId)
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
}