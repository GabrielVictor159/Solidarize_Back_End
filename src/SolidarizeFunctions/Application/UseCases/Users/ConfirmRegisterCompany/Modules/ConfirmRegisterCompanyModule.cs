using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.ConfirmRegisterCompany.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.ConfirmRegisterCompany.Modules;

public class ConfirmRegisterCompanyModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IConfirmRegisterCompanyUseCase, ConfirmRegisterCompanyUseCase>();

        services.AddSingleton<SearchRequestCompanyHandler>();
        services.AddSingleton<CreateCompanyObjectHandler>();
        services.AddSingleton<SearchCompanyHandler>();
        services.AddSingleton<SaveCompanyHandler>();
    }
}
