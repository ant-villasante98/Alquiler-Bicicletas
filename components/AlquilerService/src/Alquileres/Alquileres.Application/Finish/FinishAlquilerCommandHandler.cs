
using Alquileres.Domain;
using Alquileres.Domain.Services;
using MediatR;

namespace Alquileres.Application.Finish;

internal sealed class FinishAlquilerCommandHandler : IRequestHandler<FinishAlquilerCommand>
{
    private readonly IFinishAlquiler _finisher;

    public FinishAlquilerCommandHandler(IFinishAlquiler finisher)
    {
        _finisher = finisher;
    }

    public async Task Handle(FinishAlquilerCommand request, CancellationToken cancellationToken)
    {
        await _finisher.Finish(new AlquilerId(request.AlquilerId), new AlquilerEstacionId(request.EstacionId));
    }
}