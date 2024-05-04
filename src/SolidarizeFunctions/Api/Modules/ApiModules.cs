
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Api.Filters;
using Solidarize.Api.Interface;
using Solidarize.Api.UseCases.Users.ConfirmRegisterCompany;
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
        services.AddSingleton<IOutputPort<Application.Bundaries.RequestRegisterCompany.RequestRegisterCompanyResponse>,RequestRegisterCompanyPresenter>();
        services.AddSingleton<IOutputPort<Application.Bundaries.ConfirmRegisterCompany.ConfirmRegisterCompanyResponse>,ConfirmRegisterCompanyPresenter>();
        services.AddSingleton<IOutputPort<Application.Bundaries.RecoverPassword.RecoverPasswordResponse>,RecoverPasswordPresenter>();
    }

}
