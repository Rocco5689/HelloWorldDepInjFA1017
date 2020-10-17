using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Threading;

namespace HelloWorldDepInjFA1017
{
    public class HttpFunction1
    {
        private ISimpleCustomClass _simpleCustomClass;

        public HttpFunction1(ISimpleCustomClass simpleCustomClass)
        {
            _simpleCustomClass = simpleCustomClass;
        }

        [FunctionName("HttpFunction1")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string name = req.Query["name"];

            if(!name.ToLower().Contains("20000"))
            {
                _simpleCustomClass.SetSimpleCustomClassPrivateValue(name);
                Thread.Sleep(Convert.ToInt32(name));
            }
            else
            {
                log.LogInformation(_simpleCustomClass.ShowSimpleCustomClassPrivateValue());
            }

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            name = name ?? data?.name;

            string responseMessage = string.IsNullOrEmpty(name)
                ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
                : $"Hello, {name}. This HTTP triggered function executed successfully.";

            return new OkObjectResult(responseMessage);
        }
    }
}
