using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Shipping.GetMyShippings.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Shipping.GetMyShippings.Modules;

public class GetMyShippingsModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IGetMyShippingsUseCase, GetMyShippingsUseCase>();

        services.AddSingleton<GetMyShippingsHandler>();
    }
}
