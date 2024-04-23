using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Api.Modules;

namespace Solidarize.Helpers;

public static class ServiceCollectionExtensions
{
    public static void ConfigureServicesModules(this IServiceCollection services)
    {
        services.AddModule(new ApiModule());
    }
    public static void AddAssemblyTypes(this IServiceCollection services, Assembly assembly)
    {
        var types = assembly.GetExportedTypes();
        var registeredInterfaces = new HashSet<Type>();

        foreach (var type in types)
        {
            if (type.IsClass && !type.IsAbstract)
            {
                var interfaces = type.GetInterfaces();
                if (interfaces.Length == 0)
                {
                    services.AddSingleton(type);
                }
                else
                {
                    foreach (var @interface in interfaces)
                    {
                        if (!registeredInterfaces.Contains(@interface))
                        {
                            services.AddScoped(@interface, type);
                            registeredInterfaces.Add(@interface);
                        }
                    }
                }
            }
        }
    }

    private static void AddModule(this IServiceCollection services, Domain.Modules.Module module)
    {
        module.Configure(services);
    }
}