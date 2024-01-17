using Shared.Domain.CustomExceptions;
using Shared.Domain.Services;
using Tarifas.Domain;
using Tarifas.Domain.Repositories;
using Tarifas.Domain.Services;

namespace Tarifas.Application;
public class TarifaService : ITarifaService
{
    private readonly ITarifaRepository _repository;
    private readonly IDistributedCacheService _cache;

    public TarifaService(ITarifaRepository repository, IDistributedCacheService cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<Tarifa> Create(int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora)
    {
        Tarifa tarifa = Tarifa.Create(tipoTarifa, definicion, diaSemana, fecha, montoFijoAlquiler, montoMinutoFraccion, montoKm, montoHora);
        Tarifa savedTarifa = await _repository.Add(tarifa);
        return savedTarifa;
    }

    public async Task Delete(TarifaId id)
    {
        Tarifa tarifa = await this.GetById(id);

        await _repository.Delete(tarifa);
    }

    public async Task<List<Tarifa>> GetAll()
    {
        string cachekey = "tarifaList";
        List<Tarifa> tarifas = await _cache.GetAsync<List<Tarifa>>(cachekey);
        if (tarifas == null)
        {
            tarifas = await _repository.FindAll();
            await _cache.AddAsync(cachekey, tarifas);
        }
        return tarifas;
    }

    public async Task<Tarifa> GetByFecha(TarifaFecha fecha)
    {
        Tarifa tarifa = await _repository.FindByFecha(fecha);
        return tarifa;
    }

    public async Task<Tarifa> GetById(TarifaId id)
    {
        string cacheKey = $"tarifa.{id.Value}";
        Tarifa tarifa = await _cache.GetAsync<Tarifa>(cacheKey);
        if (tarifa == null)
        {
            tarifa = await _repository.FindById(id) ?? throw new NotFoundElementException($"No se encontro la Tarifa con id: {id.Value}");
            await _cache.AddAsync(cacheKey, tarifa);
        }
        return tarifa;
    }

    public async Task Update(TarifaId id, int tipoTarifa, char definicion, TarifaDiaSemana diaSemana, TarifaFecha fecha, TarifaMonto montoFijoAlquiler, TarifaMonto montoMinutoFraccion, TarifaMonto montoKm, TarifaMonto montoHora)
    {
        Tarifa tarifa = await this.GetById(id);
        tarifa.Update(
            tipoTarifa,
            definicion,
            diaSemana,
            fecha,
            montoFijoAlquiler,
            montoMinutoFraccion,
            montoKm,
            montoHora
        );
        await _repository.Update(tarifa);
    }
}
