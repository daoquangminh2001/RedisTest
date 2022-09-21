using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TestRedis.Installer
{
    public class SystemInstaller : IInstaller
    {
        public void InstallSevices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TestRedis", Version = "v1" });
            });
        }
    }
}
