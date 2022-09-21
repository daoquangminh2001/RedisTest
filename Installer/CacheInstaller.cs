using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StackExchange.Redis;
using TestRedis.Configurations;
using TestRedis.Services;

namespace TestRedis.Installer
{
    public class CacheInstaller : IInstaller
    {
        public void InstallSevices(IServiceCollection services, IConfiguration configuration)
        {
            var redisConfiguration = new RedisConfiguration();
            configuration.GetSection("RedisConfiguration").Bind(redisConfiguration);
            services.AddSingleton(redisConfiguration);
            if (!redisConfiguration.Enabled) return;
            services.AddSingleton<IConnectionMultiplexer>(_=> ConnectionMultiplexer.Connect(redisConfiguration.RedisConnectionString));
            services.AddStackExchangeRedisCache(option => option.Configuration = redisConfiguration.RedisConnectionString);
            services.AddSingleton<IResponseCacheServices,ResponseCacheServices>();
        }
    }
}
