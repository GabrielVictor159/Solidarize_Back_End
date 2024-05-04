using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.RecoverPassword.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.RecoverPassword.Modules;

public class RecoverPasswordModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IRecoverPasswordUseCase, RecoverPasswordUseCase>();

        services.AddSingleton<CreateRequestRecoverPasswordHandler>();
        services.AddSingleton<SearchCompanyHandler>();
        services.AddSingleton<SendEmailRecoverPasswordHandler>();
    }
}
