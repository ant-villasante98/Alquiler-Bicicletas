

using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Update;

public record EstacionUpdateCommand(
    long Id,
    [Required(ErrorMessage = "El campo 'nombre' es obligatorio.")] string Nombre,
    double Latitud,
    double Longitud
) : IRequest;