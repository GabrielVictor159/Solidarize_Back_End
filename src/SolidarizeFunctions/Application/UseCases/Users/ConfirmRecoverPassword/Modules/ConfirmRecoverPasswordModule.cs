using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Modules;

public class ConfirmRecoverPasswordModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IConfirmRecoverPasswordUseCase, ConfirmRecoverPasswordUseCase>();

        services.AddSingleton<SearchRequestRecoverPasswordHandler>();
        services.AddSingleton<CreateNewPasswordHandler>();
        services.AddSingleton<SaveNewPasswordHandler>();
    }
}
