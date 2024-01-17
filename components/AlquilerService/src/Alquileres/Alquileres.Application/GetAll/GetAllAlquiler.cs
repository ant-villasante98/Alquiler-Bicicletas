
using Alquileres.Domain;
using Alquileres.Domain.Services;
using Shared.Domain.Services;

namespace Alquileres.Application.GetAll;

public class GetAllAlquiler : IGetAllAlquiler
{
    private readonly IAlquilerRepository _repository;

    private readonly IDistributedCacheService _cache;
    public GetAllAlquiler(IAlquilerRepository repository, IDistributedCacheService cache)
    {
        _repository = repository;
        _cache = cache;
    }

    public async Task<List<Alquiler>> GetAll()
    {
        string cacheKey = "alquilerList";

        List<Alquiler> alquileres = await _cache.GetAsync<List<Alquiler>>(cacheKey);
        if (alquileres == null)
        {
            alquileres = await _repository.FindAllAsync();
            await _cache.AddAsync(cacheKey, alquileres);
        }
        return alquileres;
    }
}