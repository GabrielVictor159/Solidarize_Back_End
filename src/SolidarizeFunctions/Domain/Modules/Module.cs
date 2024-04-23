using Microsoft.Extensions.DependencyInjection;

namespace Solidarize.Domain.Modules;

public abstract class Module
{
     public abstract void Configure(IServiceCollection services);
}
