using Application.Common;
using Domain.Models;
using Domain.Services;
using MediatR;

namespace Application.GetAll;

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
        List<EstacionDto> estacionDtos = estaciones
            .Select(
                e =>
                    new EstacionDto(
                        id: e.Id.Value,
                        nombre: e.Nombre,
                        latitud: e.Latitud.Value,
                        longitud: e.Longitud.Value,
                        fechaHoraCreacion: e.FechaHoraCreacion.ToUniversalTime()
                    )
            )
            .ToList();
        return estacionDtos;
    }
}
