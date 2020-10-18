

using Microsoft.Azure.WebJobs;

namespace HelloWorldDepInjFA1017
{
    public interface ISimpleCustomClass
    {
        int SetSimpleCustomClassPrivateValue(string privateValue);
        string ShowSimpleCustomClassPrivateValue();

        void DelayExecSimpleCustomClassLog(string datetime, ExecutionContext context);
    }
}
