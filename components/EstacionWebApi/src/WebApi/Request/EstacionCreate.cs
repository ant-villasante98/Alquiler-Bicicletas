using System.ComponentModel.DataAnnotations;

namespace WebApi.Request;

public class EstacionCreate
{
    [Required(ErrorMessage = "El campo 'nombre' es obligatorio.")]
    public string Nombre { get; } = string.Empty;

    public double Latitud { get; }

    public double Longitud { get; }

    private EstacionCreate() { }

    public EstacionCreate(string nombre, double latitud, double longitud)
    {
        Nombre = nombre;
        Latitud = latitud;
        Longitud = longitud;
    }
}
