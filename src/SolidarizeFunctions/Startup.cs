using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.Executors;
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Api.Validator.Http;
using Solidarize.Helpers;

[assembly: FunctionsStartup(typeof(Startup))]
public class Startup : FunctionsStartup
{
    public override void Configure(IFunctionsHostBuilder builder)
    {
        builder.Services.AddHttpClient();
        builder.Services.ConfigureServicesModules();
    }


}



