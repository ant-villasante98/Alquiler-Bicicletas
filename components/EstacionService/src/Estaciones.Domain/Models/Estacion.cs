namespace Estaciones.Domain.Models;

public partial class Estacion
{
    public EstacionId Id { get; }

    //INFO: Verificar el la cadena vacia
    public string Nombre { get; private set; } = string.Empty;

    public DateTime FechaHoraCreacion { get; private set; }

    public EstacionLatitud Latitud { get; private set; }

    public EstacionLongitud Longitud { get; private set; }

    private Estacion() { }

    public Estacion(
        EstacionId id,
        string nombre,
        DateTime fechaHoraCreacion,
        EstacionLatitud latitud,
        EstacionLongitud longitud
    )
    {
        Id = id;
        Nombre = nombre;
        FechaHoraCreacion = fechaHoraCreacion;
        Latitud = latitud;
        Longitud = longitud;
    }

    public static Estacion Create(string nombre, EstacionLatitud latitud, EstacionLongitud longitud)
    {
        return new Estacion()
        {
            Nombre = nombre,
            FechaHoraCreacion = DateTime.UtcNow,
            Latitud = latitud,
            Longitud = longitud
        };
    }

    public void Update(string nombre, EstacionLatitud latitud, EstacionLongitud longitud)
    {
        Nombre = nombre;
        Latitud = latitud;
        Longitud = longitud;

    }

}
