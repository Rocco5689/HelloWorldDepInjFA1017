using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace HelloWorldDepInjFA1017
{
    public class SimpleCustomClass : ISimpleCustomClass
    {
        private int _privateValue;
        private ILogger _logger;

        public SimpleCustomClass(ILogger<Function1> logger)
        {
            _logger = logger;
            _logger.LogInformation($"The SimpleCustomClass Contructor has been called!!!");
        }

        public int SetSimpleCustomClassPrivateValue(string privateValue)
        {
            try
            {
                _privateValue = Convert.ToInt32(privateValue);
            }
            catch (Exception exc)
            {
                // Set up logger at later time, now swallowing exception for now
            }

            return _privateValue;            
        }

        public string ShowSimpleCustomClassPrivateValue()
        {
            return _privateValue.ToString();
        }

        public void DelayExecSimpleCustomClassLog(string datetime, ExecutionContext context)
        {
            Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(10000);
                _logger.LogInformation($"This message is from the execution at: {datetime} on execution {context.InvocationId}");
            });
            
        }
    }
}
