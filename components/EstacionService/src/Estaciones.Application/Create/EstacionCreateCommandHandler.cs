using Estaciones.Domain.Models;
using Estaciones.Domain.Services;
using MediatR;

namespace Estaciones.Application.Create;

internal class EstacionCreateCommandHandler : IRequestHandler<EstacionCreateCommand, long>
{
    private readonly IEstacionService _service;

    public EstacionCreateCommandHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task<long> Handle(EstacionCreateCommand request, CancellationToken cancellationToken)
    {
        Estacion estacion = await _service.Create(
                request.Nombre,
                new EstacionLatitud(request.Latitud),
                new EstacionLongitud(request.Longitud)
        );
        return estacion.Id.Value;
    }
}