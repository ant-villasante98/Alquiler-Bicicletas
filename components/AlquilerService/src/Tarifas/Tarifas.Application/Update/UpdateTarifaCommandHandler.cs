
using MediatR;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Tarifas.Application.Update;
public class UpdateTarifaCommandHandler : IRequestHandler<UpdateTarifaCommand>
{
    private readonly ITarifaService _service;

    public UpdateTarifaCommandHandler(ITarifaService service)
    {
        _service = service;
    }

    public async Task Handle(UpdateTarifaCommand request, CancellationToken cancellationToken)
    {
        await _service.Update(
            new TarifaId(request.Id),
            request.TipoTarifa,
            request.Definicion,
            new TarifaDiaSemana(request.DiaSemana),
            new TarifaFecha(request.DiaMes, request.Mes, request.Anio),
            new TarifaMonto(request.MontoFijoAlquiler),
            new TarifaMonto(request.MontoMinutoFraccion),
            new TarifaMonto(request.MontoKm),
            new TarifaMonto(request.MontoHora)
        );
    }
}