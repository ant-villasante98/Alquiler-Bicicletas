
using Alquileres.Application.Common;
using Alquileres.Domain;
using Alquileres.Domain.Services;
using MediatR;

namespace Alquileres.Application.GetAll;

internal class GetAllAlquilerCommandHandler : IRequestHandler<GetAllAlquilerCommand, List<AlquilerResponse>>
{
    private readonly IGetAllAlquiler _geterAll;

    public GetAllAlquilerCommandHandler(IGetAllAlquiler geterAll)
    {
        _geterAll = geterAll;
    }

    public async Task<List<AlquilerResponse>> Handle(GetAllAlquilerCommand request, CancellationToken cancellationToken)
    {
        List<Alquiler> alquileres = await _geterAll.GetAll();
        return alquileres.Select(a =>
            new AlquilerResponse(
                Id: a.Id.Value,
                Estado: (byte)a.Estado,
                Cliente: a.Cliente,
                EstacionRetiro: a.EstacionRetiro.Value,
                EstacionDevolucion: a.EstacionDevolucion?.Value,
                FechaHoraRetiro: a.FechaHoraRetiro,
                FechaHoraDevolucion: a.FechaHoraDevolucion,
                Monto: a.Monto?.Value,
                TarifaId: a.TarifaId.Value
            )
        ).ToList();
    }
}