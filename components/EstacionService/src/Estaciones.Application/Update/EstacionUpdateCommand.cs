

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Estaciones.Application.Update;

public record EstacionUpdateCommand(
    long Id,
    [Required(ErrorMessage = "El campo 'nombre' es obligatorio.")]
    string Nombre,
    [Range(-90,90,ErrorMessage ="La latitud debe estar entre -90 y 90.")]
    double Latitud,
    [Range(-180,180,ErrorMessage ="La longitud debe estar entre -180 y 180.")]
    double Longitud
) : IRequest;