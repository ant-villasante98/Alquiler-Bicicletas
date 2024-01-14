
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Application.Delete;

public record EstacionDeleteCommand(
    [Required]
    long Id
) : IRequest;