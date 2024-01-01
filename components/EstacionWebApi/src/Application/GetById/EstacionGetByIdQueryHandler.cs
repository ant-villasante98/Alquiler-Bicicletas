
using Application.Common;
using Domain.Models;
using Domain.Services;
using MediatR;

namespace Application.GetById;

internal class EstacionGetByIdQueryHandler : IRequestHandler<EstacionGetByIdQuery, EstacionDto>
{
    private readonly IEstacionService _service;

    public EstacionGetByIdQueryHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task<EstacionDto> Handle(EstacionGetByIdQuery request, CancellationToken cancellationToken)
    {
        Estacion estacion = await _service.GetById(request.Id);
        return new EstacionDto(
            id: estacion.Id,
            nombre: estacion.Nombre,
            latitud: estacion.Latitud,
            longitud: estacion.Longitud,
            fechaHoraCreacion: estacion.FechaHoraCreacion
        );
    }
}