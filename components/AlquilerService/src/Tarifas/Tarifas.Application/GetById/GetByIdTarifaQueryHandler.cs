
using MediatR;
using Tarifas.Application.Common;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Tarifas.Application.GetById;

internal class GetByIdTarifaQueryHandler : IRequestHandler<GetByIdTarifaQuery, TarifaDto>
{
    private readonly ITarifaService _service;

    public GetByIdTarifaQueryHandler(ITarifaService service)
    {
        _service = service;
    }

    public async Task<TarifaDto> Handle(GetByIdTarifaQuery request, CancellationToken cancellationToken)
    {
        Tarifa tarifa = await _service.GetById(new TarifaId(request.Id));

        return new TarifaDto(
                id: tarifa.Id.Value,
                tipoTarifa: tarifa.TipoTarifa,
                definicion: tarifa.Definicion,
                diaSemana: tarifa.DiaSemana.Value,
                diaMes: tarifa.Fecha.Dia,
                mes: tarifa.Fecha.Mes,
                anio: tarifa.Fecha.Anio,
                montoFijoAlquiler: tarifa.MontoFijoAlquiler.Value,
                montoHora: tarifa.MontoHora.Value,
                montoKm: tarifa.MontoKm.Value,
                montoMinutoFraccion: tarifa.MontoMinutoFraccion.Value
        );
    }
}