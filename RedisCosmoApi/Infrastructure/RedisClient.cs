using System.Text.Json;
using Microsoft.Extensions.Caching.Distributed;
using RedisCosmoApi.Interfaces;

namespace RedisCosmoApi.Infrastructure;

public class RedisClient : IRedisClient
{
    private readonly IDistributedCache _cache;

    public RedisClient(IDistributedCache redisCacheDatabase)
    {
        _cache = redisCacheDatabase;
    }

    public async Task DeleteValue(string keyName)
    {
        await _cache.RemoveAsync(keyName);
    }
    
    public async Task SetValue<TValue>(string keyName, TValue inputValue, int ttl = 2) where TValue : class
    {
        var data = JsonSerializer.Serialize(inputValue);
        await _cache.SetStringAsync(keyName, data,
            new DistributedCacheEntryOptions()
            {
                AbsoluteExpiration = DateTimeOffset.Now.AddMinutes(ttl)
            });
    }
    
    public async Task<string> GetValue(string keyName)
    {
        ArgumentNullException.ThrowIfNull(keyName);
        return await _cache.GetStringAsync(keyName);
    }
}