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

        //Decorator
        [Function("ExampleHttpTrigger")]
        public IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequest req)
        {

            var inputOne = req.Query["input1"];
            var inputTwo = req.Query["input2"];

            _logger.LogInformation("C# HTTP trigger function processed a request.");
            var currentSystemTime = DateTimeOffset.UtcNow;
            return new OkObjectResult($"{currentSystemTime}: Welcome to Azure Functions:\n This is the value of the first input: {inputOne}\n This is the value of the second input: {inputTwo}");
        }
    }
}
