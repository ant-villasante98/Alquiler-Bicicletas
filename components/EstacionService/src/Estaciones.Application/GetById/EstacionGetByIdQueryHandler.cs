
using Estaciones.Application.Common;
using Estaciones.Domain.Models;
using Estaciones.Domain.Services;
using MediatR;

namespace Estaciones.Application.GetById;

internal class EstacionGetByIdQueryHandler : IRequestHandler<EstacionGetByIdQuery, EstacionDto>
{
    private readonly IEstacionService _service;

    public EstacionGetByIdQueryHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task<EstacionDto> Handle(EstacionGetByIdQuery request, CancellationToken cancellationToken)
    {
        Estacion estacion = await _service.GetById(new EstacionId(request.Id));
        EstacionDto estacionDto = new EstacionDto(
            id: estacion.Id.Value,
            nombre: estacion.Nombre,
            latitud: estacion.Latitud.Value,
            longitud: estacion.Longitud.Value,
            fechaHoraCreacion: estacion.FechaHoraCreacion
        );

        return estacionDto;
    }
}