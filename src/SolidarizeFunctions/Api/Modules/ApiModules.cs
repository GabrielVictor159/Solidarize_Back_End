
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Api.Filters;
using Solidarize.Api.Interface;
using Solidarize.Api.UseCases.Users.ConfirmRecoverPassword;
using Solidarize.Api.UseCases.Users.ConfirmRegisterCompany;
using Solidarize.Api.UseCases.Users.Login;
using Solidarize.Api.UseCases.Users.PatchCompany;
using Solidarize.Api.UseCases.Users.RecoverPassword;
using Solidarize.Api.UseCases.Users.RequestRegisterCompany;
using Solidarize.Api.Validator.Http;
using Solidarize.Application.Bundaries;
using Solidarize.Application.Bundaries.RequestRegisterCompany;
using Solidarize.Domain.Modules;
using Solidarize.Helpers;

namespace Solidarize.Api.Modules;

public class ApiModule : Module
{
     public override void Configure(IServiceCollection services)
    {
        services.AddSingleton(new HttpRequestValidator());
        services.AddScoped<NotificationMiddleware>();
        services.AddSingleton<RequestRegisterCompanyPresenter>();
        services.AddSingleton<ConfirmRegisterCompanyPresenter>();
        services.AddSingleton<RecoverPasswordPresenter>();
        services.AddSingleton<ConfirmRecoverPasswordPresenter>();
        services.AddSingleton<LoginPresenter>();
        services.AddSingleton<PatchCompanyPresenter>();
    }

}
