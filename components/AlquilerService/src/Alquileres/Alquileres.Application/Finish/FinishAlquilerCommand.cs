
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Alquileres.Application.Finish;

public record FinishAlquilerCommand(
    [Required]
    long AlquilerId,
    [Required]
    long EstacionId
) : IRequest;