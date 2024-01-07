
using MediatR;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Tarifas.Application.Delete;

internal class DeleteTarifaCommandHandler : IRequestHandler<DeleteTarifaCommand>
{
    private readonly ITarifaService _service;

    public DeleteTarifaCommandHandler(ITarifaService service)
    {
        _service = service;
    }

    public async Task Handle(DeleteTarifaCommand request, CancellationToken cancellationToken)
    {
        await _service.Delete(new TarifaId(request.Id));
    }
}