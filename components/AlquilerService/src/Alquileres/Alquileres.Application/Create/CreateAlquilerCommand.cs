
using System.ComponentModel.DataAnnotations;
using Alquileres.Application.Common;
using Alquileres.Domain;
using MediatR;

namespace Alquileres.Application.Create;

public record CreateAlquilerCommand(
    string Cliente,
    [Required]
    long EstacionRetiroId
) : IRequest<AlquilerResponse>;