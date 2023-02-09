using FunctionApp29;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWorkerDefaults(workerApplication =>
    {
        workerApplication.UseMiddleware<MyMiddleware>();
    })
    .ConfigureServices(s =>
    {
        s.AddScoped<IMyScopedService, MyScopedService>();
    })
    .Build();

host.Run();
