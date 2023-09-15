using Serilog;
using WorkerService;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((builder, config) =>
    {
        var env = builder.HostingEnvironment;

        config.Sources.Clear();
        config.SetBasePath(Directory.GetCurrentDirectory());
        config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
              .AddJsonFile($"appsettings.{env.EnvironmentName}.json", false, true);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<Worker>();
    })
    .UseSerilog((builder, services, loggerConfig) => loggerConfig
        .ReadFrom.Configuration(builder.Configuration))
    .Build();

host.Run();
