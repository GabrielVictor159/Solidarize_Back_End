using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany.Modules;

public class RequestRegisterCompanyModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IRequestRegisterCompanyUseCase, RequestRegisterCompanyUseCase>();

        services.AddSingleton<CreatePasswordEntityHandler>();
        services.AddSingleton<CreateRequestCompanyEnitityHandler>();
        services.AddSingleton<SaveRequestCompanyHandler>();
        services.AddSingleton<SendRequestCompanyEmailHandler>();
        services.AddSingleton<SearchCompanyHandler>();
    }
}
