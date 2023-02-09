using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Middleware;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace FunctionApp29
{
    internal class MyMiddleware : IFunctionsWorkerMiddleware
    {
        private readonly ILogger<MyMiddleware> _logger;

        public MyMiddleware(ILogger<MyMiddleware> logger)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public async Task Invoke(FunctionContext context, FunctionExecutionDelegate next)
        {
            var _scopedService = context.InstanceServices.GetRequiredService<IMyScopedService>();

            var serviceId = _scopedService.GetId();
            _logger.LogInformation($"Inside Middlewr. IMyScopedService.Id:{serviceId}");

            await next(context);
        }
    }
}
