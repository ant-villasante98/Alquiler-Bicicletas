

using System.ComponentModel.DataAnnotations;
using System.Net;
using MediatR;

namespace Application.Create;

public record EstacionCreateCommand(
    [Required(ErrorMessage = "El campo 'nombre' es obligatorio.")]
    string Nombre,
    [Range(-90,90,ErrorMessage ="La latitud debe estar entre -90 y 90.")]
    double Latitud,
    [Range(-180,180,ErrorMessage ="La longitud debe estar entre -180 y 180.")]
    double Longitud
) : IRequest<long>;



