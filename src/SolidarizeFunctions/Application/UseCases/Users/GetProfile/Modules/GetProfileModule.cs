using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.GetProfile.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.GetProfile.Modules;

public class GetProfileModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IGetProfileUseCase, GetProfileUseCase>();

        services.AddSingleton<GetCompanyDBHandler>();
    }
}
