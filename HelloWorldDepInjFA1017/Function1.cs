using System;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace HelloWorldDepInjFA1017
{
    public class Function1
    {
        private ISimpleCustomClass _simpleCustomClass;

        public Function1(ISimpleCustomClass simpleCustomClass)
        {
            _simpleCustomClass = simpleCustomClass;
        }

        [Disable]
        [FunctionName("Function1")]
        public void Run([TimerTrigger("*/5 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");

            log.LogInformation($"Settings _privateValue field of SimpleCustom Class with a string value of 5 using SetSimpleCustomClassPrivateValue(\"5\")");
            _simpleCustomClass.SetSimpleCustomClassPrivateValue("5");

            log.LogInformation($"Using ShowSimpleCustomClassPrivateValue() to view the value of SimpleCustomClass _privateValue: {_simpleCustomClass.ShowSimpleCustomClassPrivateValue()}");
        }
    }
}
