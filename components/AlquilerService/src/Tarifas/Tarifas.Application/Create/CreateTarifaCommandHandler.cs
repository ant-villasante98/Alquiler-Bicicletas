
using MediatR;
using Tarifas.Application.Common;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Tarifas.Application.Create;

internal class CreateTarifaCommandHandler : IRequestHandler<CreateTarifaCommand, long>
{
    private readonly ITarifaService _service;

    public CreateTarifaCommandHandler(ITarifaService service)
    {
        _service = service;
    }

    public async Task<long> Handle(CreateTarifaCommand request, CancellationToken cancellationToken)
    {
        Tarifa tarifa = await _service.Create(
            tipoTarifa: request.TipoTarifa,
            definicion: request.Definicion,
            diaSemana: new TarifaDiaSemana(request.DiaSemana),
            fecha: new TarifaFecha(request.DiaMes, request.Mes, request.Anio),
            montoFijoAlquiler: new TarifaMonto(request.MontoFijoAlquiler),
            montoMinutoFraccion: new TarifaMonto(request.MontoMinutoFraccion),
            montoKm: new TarifaMonto(request.MontoKm),
            montoHora: new TarifaMonto(request.MontoHora));
        return tarifa.Id.Value;
    }
}