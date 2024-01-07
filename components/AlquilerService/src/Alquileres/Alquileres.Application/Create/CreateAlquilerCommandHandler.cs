
using Alquileres.Application.Common;
using Alquileres.Domain;
using Alquileres.Domain.Services;
using MediatR;

namespace Alquileres.Application.Create;

internal class CreateAlquilerCommandHandler : IRequestHandler<CreateAlquilerCommand, AlquilerResponse>
{
    private readonly ICreateAlquiler _creator;

    public CreateAlquilerCommandHandler(ICreateAlquiler creator)
    {
        _creator = creator;
    }

    public async Task<AlquilerResponse> Handle(CreateAlquilerCommand request, CancellationToken cancellationToken)
    {
        Alquiler alquiler = await _creator.Create(
            cliente: request.Cliente,
            estacionRetiro: new AlquilerEstacionId(request.EstacionRetiroId)
        );
        return new AlquilerResponse(
            id: alquiler.TarifaId.Value,
            estado: (byte)alquiler.Estado,
            cliente: alquiler.Cliente,
            estacionRetiro: alquiler.EstacionRetiro.Value,
            estacionDevolucion: alquiler.EstacionDevolucion?.Value,
            fechaHoraRetiro: alquiler.FechaHoraRetiro,
            fechaHoraDevolucion: alquiler.FechaHoraDevolucion,
            monto: alquiler.Monto?.Value,
            tarifaId: alquiler.TarifaId.Value
        );
    }
}