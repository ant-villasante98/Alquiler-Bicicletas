
using MediatR;
using Tarifas.Application.Common;

namespace Tarifas.Application.Create;

public record CreateTarifaCommand(
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
) : IRequest<long>;