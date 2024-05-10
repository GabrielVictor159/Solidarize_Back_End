using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.Login.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.Login.Modules;

public class LoginModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<ILoginUseCase, LoginUseCase>();
        
        services.AddSingleton<LoginDbHandler>();
        services.AddSingleton<GenerateTokenHandler>();
    }

}
