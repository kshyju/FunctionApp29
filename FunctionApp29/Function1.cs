using System.Globalization;
using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;

namespace FunctionApp29
{
    public class Function1
    {
        private readonly ILogger _logger;
        private readonly IMyScopedService _myScopedService;
        public Function1(ILoggerFactory loggerFactory, IMyScopedService myScopedService)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
            _myScopedService = myScopedService;
        }

        [Function("Function1")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequestData req)
        {
            var serviceId = _myScopedService.GetId();

            _logger.LogInformation($"Inside Function. IMyScopedService.Id:{serviceId}");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "text/html; charset=utf-8");
            response.WriteString($"<h2>IMyScopedService.Id: {serviceId}</h2>");

            return response;
        }
    }
}
