using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TestRedis.Installer
{
    public interface IInstaller
    {
        void InstallSevices(IServiceCollection services,IConfiguration configuration);
    }
}
