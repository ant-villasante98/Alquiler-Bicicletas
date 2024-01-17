
using System.Text.Json;
using Estaciones.Application.Common;
using Estaciones.Domain.Services;
using Microsoft.Extensions.Caching.Distributed;

namespace Estaciones.Infrastructure.Services;

public class DistriutedCacheService : IDistributedCacheService
{
    private readonly IDistributedCache _cache;

    public DistriutedCacheService(IDistributedCache cache)
    {
        _cache = cache;
    }

    public async Task AddAsync<T>(string key, T obj) where T : class
    {

        Console.WriteLine("Guardando en Redis.");
        var options = new DistributedCacheEntryOptions()
                        .SetAbsoluteExpiration(DateTime.Now.AddMinutes(10))
                        .SetSlidingExpiration(TimeSpan.FromHours(2));
        byte[] value = ToByte(obj);
        await _cache.SetAsync(key, value, options);
    }

    public async Task<T?> GetAsync<T>(string key) where T : class
    {
        Console.WriteLine("Consultando Redis.");
        var value = await _cache.GetAsync(key);
        if (value == null)
        {
            return null;
        }

        return FromByte<T>(value);
    }

    private byte[] ToByte<T>(T obj) where T : class
    {
        return JsonSerializer.SerializeToUtf8Bytes(obj);
    }

    private T FromByte<T>(byte[] data) where T : class
    {
        return JsonSerializer.Deserialize<T>(data);
    }


}