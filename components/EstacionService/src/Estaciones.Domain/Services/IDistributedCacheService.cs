
namespace Estaciones.Domain.Services;

public interface IDistributedCacheService
{
    Task<T?> GetAsync<T>(string key) where T : class;

    Task AddAsync<T>(string key, T value) where T : class;

}