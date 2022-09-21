using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace TestRedis.Installer
{
    public static class InstallerExtensions
    {
        public static void InstallerSeviceInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            // lấy ra hết class trong IInstaller bỏ interface && abstract
            var installer = typeof(Startup).Assembly.ExportedTypes
                .Where(x=>typeof(IInstaller).IsAssignableFrom(x) && !x.IsAbstract && !x.IsInterface)
                .Select(Activator.CreateInstance).Cast<IInstaller>().ToList();
            installer.ForEach(installer => installer.InstallSevices(services,configuration));
        }
    }
}
