namespace Domain.Models;

public partial class Estacion
{
    public long Id { get; }

    //INFO: Verificar el la cadena vacia
    public string Nombre { get; } = string.Empty;

    public DateTime FechaHoraCreacion { get; }

    public double Latitud { get; }

    public double Longitud { get; }

    private Estacion() { }

    public Estacion(
        long id,
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
        return new Estacion(0, nombre, DateTime.Now, latitud, longitud);
    }

    //public Estacion FechaKind(DateTimeKind kind)
    //{
    //    return new Estacion(
    //        id: Id,
    //        nombre: Nombre,
    //        fechaHoraCreacion: DateTime.SpecifyKind(FechaHoraCreacion, kind),
    //        latitud: Latitud,
    //        longitud: Longitud
    //    );
    //}
}
