using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AzureFunctionExample
{
    public class ExampleHttpTrigger
    {
        private readonly ILogger<ExampleHttpTrigger> _logger;

        public ExampleHttpTrigger(ILogger<ExampleHttpTrigger> logger)
        {
            _logger = logger;
        }

        [Function("ExampleHttpTrigger")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {

            var example1 = req.Query["example1"];
            var example2 = req.Query["example2"];

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            return new OkObjectResult($"Welcome to Azure Functions, {example1}! Your second parameter is {example2}");
        }
    }
}
