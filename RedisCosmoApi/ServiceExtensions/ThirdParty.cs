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
                "https://localhost:8081/",
                "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==",
                "db"
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