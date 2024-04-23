
using Microsoft.Extensions.DependencyInjection;
using Solidarize.Api.Interface;
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
        services.AddSingleton<IOutputPort<Application.Bundaries.RequestRegisterCompany.RequestRegisterCompanyResponse>,RequestRegisterCompanyPresenter>();
        services.AddSingleton(new RequestRegisterCompanyPresenter());
    }

}
