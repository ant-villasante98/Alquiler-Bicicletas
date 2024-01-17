
using Estaciones.Domain.Models;
using Estaciones.Domain.Services;
using MediatR;

namespace Estaciones.Application.Update;

public class EstacionUpdateCommandHandler : IRequestHandler<EstacionUpdateCommand>
{
    private readonly IEstacionService _service;

    public EstacionUpdateCommandHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task Handle(EstacionUpdateCommand request, CancellationToken cancellationToken)
    {
        await _service.Update(
            new EstacionId(request.Id),
            request.Nombre,
            new EstacionLatitud(request.Latitud),
            new EstacionLongitud(request.Longitud)
            );
    }
}