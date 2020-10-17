# HelloWorldDepInjFA1017
Azure Function App | Dependency Injection | Hello World Example | Timer and Http Trigger samples

## Dependency Injection Hello World Baseline Example with Steps

### Build versions used

Azure Functions Core Tools (3.0.2931 Commit hash: d552c6741a37422684f0efab41d541ebad2b2bd2)  
Function Runtime Version: 3.0.14492.0

### Steps

Basic outline from a template V3 Function App (Visual Studio 2019)

1. Create Function App V3
   * Timer Function ```(*/5 * * * * *)``` *Trigger Every 5 seconds* </br></br>
1. Install NuGet Package **Microsoft.Azure.Functions.Extensions** ([Function Startup Prerequisites](https://docs.microsoft.com/bs-latn-ba/azure/azure-functions/functions-dotnet-dependency-injection#prerequisites)) </br></br>
1. Add Startup.cs File to Project </br></br>
   1. ![Add Startup.cs](https://github.com/Rocco5689/HelloWorldDepInjFA1017/blob/DepInjClassInstCheck1017/AddStartup.gif)</br></br>
