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
            // Get the Middle European Time (MEZ) time zone
            TimeZoneInfo mezTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");

            // Get current time in MEZ
            DateTime mezTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, mezTimeZone);
            return new OkObjectResult($"{mezTime}: Welcome to Azure Functions:\n This is the value of the first input: {inputOne}\n This is the value of the second input: {inputTwo}");
        }
    }
}
