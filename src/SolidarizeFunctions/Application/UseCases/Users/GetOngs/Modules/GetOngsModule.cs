using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.GetOngs.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.GetOngs.Modules;

public class GetOngsModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IGetOngsUseCase, GetOngsUseCase>();

        services.AddSingleton<GetCompaniesDBHandler>();
    }
}
