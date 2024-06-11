using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.GetCompanys.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.GetCompanys.Modules;

public class GetCompanysModule: Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IGetCompanysUseCase, GetCompanysUseCase>();

        services.AddSingleton<SearchCompaniesHandler>();
    }
    
}
