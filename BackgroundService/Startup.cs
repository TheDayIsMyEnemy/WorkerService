using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace BackgroundService
{
    public class Startup
    {
        public static IHost BuildHost(params string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(
                    (builder, config) =>
                    {
                        config.Sources.Clear();

                        var env = builder.HostingEnvironment;
                        config.SetBasePath(
                            Path.Combine(Directory.GetCurrentDirectory(), "src", "")
                        );

                        config
                            .AddJsonFile("appsettings.json", false, true)
                            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false, true);

                        config.AddEnvironmentVariables();

                        var configRoot = config.Build();
                    }
                )
                .ConfigureServices(
                    (builder, services) =>
                    {
                        // var connectionStr = builder.Configuration.GetConnectionString("Default");

                        // services.AddDbContext<AppDbContext>(
                        //     options =>
                        //         options
                        //             .UseMySql(
                        //                 connectionStr,
                        //                 ServerVersion.AutoDetect(connectionStr)
                        //             )
                        //             .LogTo(Console.WriteLine, LogLevel.Error)
                        // );

                        // services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
                        // >();
                    }
                )
                .ConfigureLogging(
                    (builder, loggingConfig) => {
                        // loggingConfig.();
                        // loggingConfig.AddConsole();
                    }
                )
                .Build();
        }
    }
}
