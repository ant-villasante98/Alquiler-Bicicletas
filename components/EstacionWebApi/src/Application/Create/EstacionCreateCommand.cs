

using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;

namespace Application.Create;

public record EstacionCreateCommand(
    [Required(ErrorMessage = "El campo 'nombre' es obligatorio.")] string Nombre,
    double Latitud,
    double Longitud
) : IRequest<long>;

//private EstacionCreateCommand() { }

//public EstacionCreateCommand(string nombre, double latitud, double longitud)
//{
//    Nombre = nombre;
//    Latitud = latitud;
//    Longitud = longitud;
//}

