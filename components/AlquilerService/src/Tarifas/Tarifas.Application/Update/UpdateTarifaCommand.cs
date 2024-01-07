
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Tarifas.Application.Update;

public record UpdateTarifaCommand(
    [Required]
    long Id,
    int TipoTarifa,
    char Definicion,
    int? DiaSemana,
    int? DiaMes,
    int? Mes,
    int? Anio,
    double MontoFijoAlquiler,
    double MontoMinutoFraccion,
    double MontoKm,
    double MontoHora
) : IRequest;