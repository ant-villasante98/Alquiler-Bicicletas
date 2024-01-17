using Estaciones.Application.Utility;
using Estaciones.Domain.CustomExeptions;
using Estaciones.Domain.Models;
using Estaciones.Domain.Repositories;
using Estaciones.Domain.Services;

namespace Estaciones.Application.Services;

public class EstacionService : IEstacionService
{
    private readonly IEstacionRepository _repository;
    private readonly IDistributedCacheService _cache;

    public EstacionService(IEstacionRepository repository, IDistributedCacheService cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<double> CalcularDistancia(EstacionId origenId, EstacionId destinoId)
    {
        Estacion estacionOrigen = await GetById(origenId);
        Estacion estacionDestino = await GetById(destinoId);
        double distancia = CalculadorDistcia.CalcularDistancia(
            latitudOrigen: estacionOrigen.Latitud.Value,
            longitudOrigen: estacionOrigen.Longitud.Value,
            latitudDestino: estacionDestino.Latitud.Value,
            longitudDestino: estacionDestino.Longitud.Value
        );
        return distancia;
    }

    public async Task<Estacion> Create(string nombre, EstacionLatitud latitud, EstacionLongitud longitud)
    {
        try
        {
            Estacion estacion = await _repository.Add(Estacion.Create(nombre, latitud, longitud));
            return estacion;
        }
        catch
        {
            //Console.WriteLine(ex);
            throw new CouldNotUpdateDBException("No se pudo agregar la Estacion.");
        }
    }

    public async Task Delete(EstacionId id)
    {
        Estacion estacion = await this.GetById(id);
        try
        {
            await _repository.Delete(estacion);
        }
        catch (Exception)
        {
            throw new CouldNotUpdateDBException($"No se pudo eliminar la Estacion con id: {id.Value}");
        }
    }

    public async Task<List<Estacion>> GetAll()
    {

        string cacheKey = $"estacionList";

        List<Estacion> estaciones = await _cache.GetAsync<List<Estacion>>(cacheKey);
        if (estaciones == null)
        {
            estaciones = await _repository.FindAll();
            await _cache.AddAsync(cacheKey, estaciones);

        }
        return estaciones;
    }

    public async Task<Estacion> GetById(EstacionId id)
    {
        string cacheKey = $"estacion.{id.Value.ToString()}";
        Estacion estacion = await _cache.GetAsync<Estacion>(cacheKey);
        if (estacion == null)
        {
            estacion = await _repository.FindbyId(id) ?? throw new NotFoundElementException($"No se pudo encontrar la Estcion con id: {id.Value}");
            await _cache.AddAsync(cacheKey, estacion);
        }
        return estacion;
    }

    public async Task Update(EstacionId id, string nombre, EstacionLatitud latitud, EstacionLongitud longitud)
    {
        Estacion estacion = await this.GetById(id);
        try
        {
            estacion.Update(
                nombre,
                latitud,
                longitud
            );
            await _repository.Update(estacion);
        }
        catch (Exception)
        {
            throw new CouldNotUpdateDBException($"No se pudo actualizar la Estacion con id: {id}");
        }
    }
}
