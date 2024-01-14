using Alquileres.Application.Common;
using Alquileres.Domain;
using Alquileres.Domain.Services;
using MediatR;
using Tarifas.Domain;

namespace Alquileres.Application.Create;

internal class CreateAlquilerCommandHandler
    : IRequestHandler<CreateAlquilerCommand, AlquilerResponse>
{
    private readonly ICreateAlquiler _creator;

    public CreateAlquilerCommandHandler(ICreateAlquiler creator)
    {
        _creator = creator;
    }

    public async Task<AlquilerResponse> Handle(
        CreateAlquilerCommand request,
        CancellationToken cancellationToken
    )
    {
        Alquiler alquiler = await _creator.Create(
            cliente: request.Cliente,
            estacionRetiro: new AlquilerEstacionId(request.EstacionRetiroId)
        );

        return new AlquilerResponse(
            Id: alquiler.Id.Value,
            Estado: (byte)alquiler.Estado,
            Cliente: alquiler.Cliente,
            EstacionRetiro: alquiler.EstacionRetiro.Value,
            EstacionDevolucion: alquiler.EstacionDevolucion?.Value,
            FechaHoraRetiro: alquiler.FechaHoraRetiro.Value,
            FechaHoraDevolucion: alquiler.FechaHoraDevolucion?.Value,
            Monto: alquiler.Monto?.Value,
            TarifaId: alquiler.TarifaId.Value
        );
    }
}

