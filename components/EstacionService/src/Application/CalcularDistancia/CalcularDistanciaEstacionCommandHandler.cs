
using Domain.Models;
using Domain.Services;
using MediatR;

namespace Application.CalcularDistancia;

public class CalcularDistanciaEstacionCommandHandler : IRequestHandler<CalcularDistanciaEstacionCommand, DistanciaResponse>
{
    private readonly IEstacionService _service;

    public CalcularDistanciaEstacionCommandHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task<DistanciaResponse> Handle(CalcularDistanciaEstacionCommand request, CancellationToken cancellationToken)
    {
        double distancia = await _service.CalcularDistancia(
            origenId: new EstacionId(request.EstacionOrigenId),
            destinoId: new EstacionId(request.EstacionDestinoId)
        );
        return new DistanciaResponse(distancia);
    }
}