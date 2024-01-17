
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Estaciones.Application.Delete;

public record EstacionDeleteCommand(
    [Required]
    long Id
) : IRequest;