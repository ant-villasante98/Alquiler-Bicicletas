namespace Estaciones.Application.Common;

public class EstacionDto
{
    public long Id { get; }

    public string Nombre { get; } = string.Empty;

    public double Latitud { get; }

    public double Longitud { get; }

    public DateTime FechaHoraCreacion { get; }

    private EstacionDto() { }

    public EstacionDto(
        long id,
        string nombre,
        double latitud,
        double longitud,
        DateTime fechaHoraCreacion
    )
    {
        Id = id;
        Nombre = nombre;
        Latitud = latitud;
        Longitud = longitud;
        FechaHoraCreacion = fechaHoraCreacion;
    }
}
