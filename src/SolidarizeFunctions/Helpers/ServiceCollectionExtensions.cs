using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Api.Modules;
using Solidarize.Infraestructure.Modules;

namespace Solidarize.Helpers;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServicesModules(this IServiceCollection services)
    {
        services.AddModule(new ApiModule());
        services.AddModule(new ApplicationModule());
        services.AddModule(new InfraestructureModule());
    }


    private static void AddModule(this IServiceCollection services, Domain.Modules.Module module)
    {
        module.Configure(services);
    }
}