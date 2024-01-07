
using MediatR;
using Tarifas.Application.Common;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Tarifas.Application.GetAll;

internal class GetAllTarifaQueryHandler : IRequestHandler<GetAllTarifaQuery, List<TarifaDto>>
{
    private readonly ITarifaService _service;

    public GetAllTarifaQueryHandler(ITarifaService service)
    {
        _service = service;
    }

    public async Task<List<TarifaDto>> Handle(GetAllTarifaQuery request, CancellationToken cancellationToken)
    {
        List<Tarifa> tarifas = await _service.GetAll();
        return tarifas.Select(t =>
            new TarifaDto(
                id: t.Id.Value,
                tipoTarifa: t.TipoTarifa,
                definicion: t.Definicion,
                diaSemana: t.DiaSemana.Value,
                diaMes: t.Fecha.Dia,
                mes: t.Fecha.Mes,
                anio: t.Fecha.Anio,
                montoFijoAlquiler: t.MontoFijoAlquiler.Value,
                montoHora: t.MontoHora.Value,
                montoKm: t.MontoKm.Value,
                montoMinutoFraccion: t.MontoMinutoFraccion.Value
            )
        ).ToList();
    }
}