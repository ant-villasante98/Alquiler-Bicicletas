
using Domain.Models;
using Domain.Services;
using MediatR;

namespace Application.Update;

public class EstacionUpdateCommandHandler : IRequestHandler<EstacionUpdateCommand>
{
    private readonly IEstacionService _service;

    public EstacionUpdateCommandHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task Handle(EstacionUpdateCommand request, CancellationToken cancellationToken)
    {
        await _service.Update(request.Id, request.Nombre, request.Latitud, request.Longitud);
    }
}