using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BackgroundService
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            using var host = Startup.BuildHost(args);
            await host.StartAsync();
            var lifetime = host.Services.GetRequiredService<IHostApplicationLifetime>();

            var services = host.Services;

            var config = services.GetRequiredService<IConfiguration>();
            var env = services.GetRequiredService<IHostEnvironment>();
            var logger = services.GetRequiredService<ILogger<Program>>();
        }
    }
}
