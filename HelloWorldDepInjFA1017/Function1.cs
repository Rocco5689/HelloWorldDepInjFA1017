using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace HelloWorldDepInjFA1017
{
    public class Function1
    {
        private ISimpleCustomClass _simpleCustomClass;
        private ILogger _logger;

        private string _datetime;

        public Function1(ISimpleCustomClass simpleCustomClass, ILogger<Function1> logger)
        {
            _simpleCustomClass = simpleCustomClass;
            _logger = logger;
        }

        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log, ExecutionContext context)
        {
            _datetime = DateTime.Now.ToString();

            log.LogInformation($"C# Timer trigger function executed at: {_datetime}");

            log.LogInformation($"Settings _privateValue field of SimpleCustom Class with a string value of 5 using SetSimpleCustomClassPrivateValue(\"5\")");
            _simpleCustomClass.SetSimpleCustomClassPrivateValue("5");

            log.LogInformation($"Using ShowSimpleCustomClassPrivateValue() to view the value of SimpleCustomClass _privateValue: {_simpleCustomClass.ShowSimpleCustomClassPrivateValue()}");

            _simpleCustomClass.DelayExecSimpleCustomClassLog(_datetime, context);
        }
    }
}
