
using Alquileres.Domain;
using Alquileres.Domain.Estacion;
using Alquileres.Domain.Services;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Alquileres.Application.Finish;

public class FinishAlquiler : IFinishAlquiler
{
    private readonly IAlquilerRepository _repository;
    private readonly IEstacionService _estacionService;
    private readonly ITarifaService _tarifaService;

    public FinishAlquiler(IAlquilerRepository repository, IEstacionService estacionService)
    {
        _repository = repository;
        _estacionService = estacionService;
    }

    public async Task Finish(AlquilerId id, AlquilerEstacionId estacionId)
    {
        if (await _repository.FindByIdAsync(id) is not Alquiler alquiler)
        {
            // TODO: cambiar exception
            throw new Exception($"Not found id :{id.Value}");
        }
        EstacionDistancia distancia = await _estacionService.CalculateDistance(alquiler.EstacionRetiro, estacionId);

        alquiler.Finish(estacionId, distancia);

        await _repository.UpdateAsync(alquiler);
    }


}