
using Alquileres.Domain;
using Alquileres.Domain.Services;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Alquileres.Application.Create;

public class CreateAlquiler : ICreateAlquiler
{
    private readonly IAlquilerRepository _repository;
    private readonly IEstacionService _existEstacion;
    private readonly ITarifaService _tarifaService;

    public CreateAlquiler(IAlquilerRepository repository, IEstacionService existEstacion, ITarifaService tarifaService)
    {
        _repository = repository;
        _existEstacion = existEstacion;
        _tarifaService = tarifaService;
    }

    public async Task<Alquiler> Create(string cliente, AlquilerEstacionId estacionRetiro)
    {
        await _existEstacion.VerifyExistanceEstacion(estacionRetiro);
        Alquiler alquiler = Alquiler.StartAlquiler(
            cliente: cliente,
            estacionRetiro: estacionRetiro
        );
        DateTime fechaRetiro = alquiler.FechaHoraRetiro;
        TarifaFecha tarifaFecha = new TarifaFecha(
                    dia: fechaRetiro.Day,
                    mes: fechaRetiro.Month,
                    anio: fechaRetiro.Year
                );
        if (await _tarifaService.GetByFecha(tarifaFecha)
            is Tarifa specialTarifa
        )
        {
            alquiler.SetSpecialTarifa(specialTarifa.Id);
        }

        Alquiler savedAlquiler = await _repository.AddAsync(alquiler);

        return savedAlquiler;
    }
}