
using Domain.Models;
using Domain.Services;
using MediatR;

namespace Application.Delete;

internal class EstacionDeleteCommandHandler : IRequestHandler<EstacionDeleteCommand>
{
    private readonly IEstacionService _service;

    public EstacionDeleteCommandHandler(IEstacionService service)
    {
        _service = service;
    }

    public async Task Handle(EstacionDeleteCommand request, CancellationToken cancellationToken)
    {
        await _service.Delete(new EstacionId(request.Id));
    }
}