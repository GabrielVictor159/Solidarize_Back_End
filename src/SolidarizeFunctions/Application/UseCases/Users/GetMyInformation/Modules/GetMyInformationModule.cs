using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.GetMyInformation.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.GetMyInformation.Modules;

public class GetMyInformationModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IGetMyInformationUseCase, GetMyInformationUseCase>();

        services.AddSingleton<GetCompanyDBHandler>();
    }
}
