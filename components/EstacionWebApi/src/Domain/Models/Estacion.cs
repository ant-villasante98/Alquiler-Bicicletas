namespace Domain.Models;

public partial class Estacion
{
    public EstacionId Id { get; }

    //INFO: Verificar el la cadena vacia
    public string Nombre { get; private set; } = string.Empty;

    public DateTime FechaHoraCreacion { get; private set; }

    public double Latitud { get; private set; }

    public double Longitud { get; private set; }

    private Estacion() { }

    public Estacion(
        EstacionId id,
        string nombre,
        DateTime fechaHoraCreacion,
        double latitud,
        double longitud
    )
    {
        Id = id;
        Nombre = nombre;
        FechaHoraCreacion = fechaHoraCreacion;
        Latitud = latitud;
        Longitud = longitud;
    }

    public static Estacion Create(string nombre, double latitud, double longitud)
    {
        return new Estacion()
        {
            Nombre = nombre,
            FechaHoraCreacion = DateTime.UtcNow,
            Latitud = latitud,
            Longitud = longitud
        };
    }

    public void Update(string nombre, double latitud, double longitud)
    {
        Nombre = nombre;
        Latitud = latitud;
        Longitud = longitud;

    }

}
