
using Alquileres.Domain;
using Alquileres.Domain.Estacion;
using Alquileres.Domain.Services;
using Shared.Domain.CustomExceptions;
using Tarifas.Domain;
using Tarifas.Domain.Services;

namespace Alquileres.Application.Finish;

public class FinishAlquiler : IFinishAlquiler
{
    private readonly IAlquilerRepository _repository;
    private readonly IEstacionService _estacionService;
    private readonly IAlquilerService _alquilerService;

    public FinishAlquiler(IAlquilerRepository repository, IEstacionService estacionService, IAlquilerService alquilerService)
    {
        _repository = repository;
        _estacionService = estacionService;
        _alquilerService = alquilerService;
    }

    public async Task Finish(AlquilerId id, AlquilerEstacionId estacionId)
    {
        if (await _repository.FindByIdAsync(id) is not Alquiler alquiler)
        {
            // TODO: cambiar exception
            throw new NotFoundElementException($"No se encontro el Alquiler con id:{id.Value}");
        }
        EstacionDistancia distancia = await _estacionService.CalculateDistance(alquiler.EstacionRetiro, estacionId);

        alquiler.Finish(estacionId);
        DateTime fechaDevolucion = alquiler.FechaHoraDevolucion?.Value ?? throw new NullReferenceException("La fecha de devolucion no puede ser null.");
        AlquilerMonto montoTotal = _alquilerService.CalcularMontoTotal(fechaDevolucion - alquiler.FechaHoraRetiro.Value, alquiler.Tarifa, distancia);
        alquiler.SetAlquilerMonto(montoTotal);

        await _repository.UpdateAsync(alquiler);
    }
}