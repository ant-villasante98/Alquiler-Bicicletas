using Estaciones.Application.Common;
using Estaciones.Domain.Models;
using Estaciones.Domain.Services;
using MediatR;

namespace Estaciones.Application.GetAll;

internal sealed class EstacionesGetAllQueryHandler
    : IRequestHandler<EstacionesGetAllQuery, List<EstacionDto>>
{
    private readonly IEstacionService _service;

    public EstacionesGetAllQueryHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task<List<EstacionDto>> Handle(
        EstacionesGetAllQuery query,
        CancellationToken cancellationToken
    )
    {
        List<Estacion> estaciones = await _service.GetAll();
        List<EstacionDto> estacionesDto = estaciones
            .Select(e =>
                    new EstacionDto(
                        id: e.Id.Value,
                        nombre: e.Nombre,
                        latitud: e.Latitud.Value,
                        longitud: e.Longitud.Value,
                        fechaHoraCreacion: e.FechaHoraCreacion.ToUniversalTime()
                    )
            )
            .ToList();

        return estacionesDto;
    }
}
