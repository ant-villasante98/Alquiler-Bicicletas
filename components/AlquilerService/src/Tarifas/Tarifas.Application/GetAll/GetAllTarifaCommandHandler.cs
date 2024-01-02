
using MediatR;
using Tarifas.Application.Common;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Tarifas.Application.GetAll;

internal class GetAllTarifaCommandHandler : IRequestHandler<GetAllTarifaCommand, List<TarifaResponse>>
{
    private readonly ITarifaService _service;

    public GetAllTarifaCommandHandler(ITarifaService service)
    {
        _service = service;
    }

    public async Task<List<TarifaResponse>> Handle(GetAllTarifaCommand request, CancellationToken cancellationToken)
    {
        List<Tarifa> tarifas = await _service.GetAll();
        return tarifas.Select(t =>
            new TarifaResponse(
                id: t.Id.Value,
                tipoTarifa: t.TipoTarifa,
                definicion: t.Definicion,
                diaSemana: t.DiaSemana.Value,
                diaMes: t.Fecha.Dia,
                mes: t.Fecha.Mes,
                anio: t.Fecha.Anio,
                montoFijoAlquiler: t.MontoMinutoFraccion.Value,
                montoHora: t.MontoHora.Value,
                montoKm: t.MontoHora.Value,
                montoMinutoFraccion: t.MontoMinutoFraccion.Value
            )
        ).ToList();
    }
}