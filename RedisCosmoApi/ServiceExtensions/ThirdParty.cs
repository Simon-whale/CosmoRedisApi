using Microsoft.EntityFrameworkCore;
using RedisCosmoApi.Context;
using StackExchange.Redis;

namespace RedisCosmoApi.ServiceExtensions;

public static class ThirdParty
{
    public static void AddThirdParty(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddDbContext<CosmoContext>(options =>
            options.UseCosmos(
                config.GetValue<string>("CosmosDb:Account"),
                config.GetValue<string>("CosmosDb:Key"),
                config.GetValue<string>("CosmosDb:DatabaseName")
            )
        );

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = config.GetValue<string>("RedisCache:Host");
            options.ConfigurationOptions = new ConfigurationOptions()
            {
                EndPoints = { $"{config.GetValue<string>("RedisCache:Host")}"},
                User = config.GetValue<string>("RedisCache:User"),
                Password = config.GetValue<string>("RedisCache:Password"),
            };
        });
    }
}