

using Domain.Models;
using Domain.Services;
using MediatR;

namespace Application.Create;

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
                request.Latitud,
                request.Longitud
        );
        return estacion.Id;
    }
}