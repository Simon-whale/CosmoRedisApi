namespace RedisCosmoApi.Interfaces;

public interface IRedisClient
{
    Task<string> GetValue(string keyName);
    Task SetValue<TValue>(string keyName, TValue inputValue, int ttl = 120) where TValue: class;
    Task DeleteValue(string keyName);
}