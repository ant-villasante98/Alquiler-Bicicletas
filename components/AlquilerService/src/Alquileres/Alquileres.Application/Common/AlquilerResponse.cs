
using System.ComponentModel.DataAnnotations;

namespace Alquileres.Application.Common;

public record AlquilerResponse(
    [Required]
    long Id,
    [Required]
    byte Estado,
    [Required]
    string Cliente,
    [Required]
    long EstacionRetiro,
    long? EstacionDevolucion,
    [Required]
    DateTime FechaHoraRetiro,
    DateTime? FechaHoraDevolucion,
    double? Monto,
    [Required]
    long TarifaId
);