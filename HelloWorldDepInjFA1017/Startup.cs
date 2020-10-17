using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

[assembly: FunctionsStartup(typeof(HelloWorldDepInjFA1017.Startup))]

namespace HelloWorldDepInjFA1017
{
    class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddSingleton<ISimpleCustomClass, SimpleCustomClass>();
        }
    }
}
