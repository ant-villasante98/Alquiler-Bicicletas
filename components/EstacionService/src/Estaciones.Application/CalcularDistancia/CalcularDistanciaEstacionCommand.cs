
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Estaciones.Application.CalcularDistancia;

public record CalcularDistanciaEstacionCommand(
    [Required]
    long EstacionOrigenId,
    [Required]
    long EstacionDestinoId
) : IRequest<DistanciaResponse>;