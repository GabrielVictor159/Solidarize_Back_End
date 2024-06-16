using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Shipping.GetMessagesDiscution.Handlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Shipping.GetMessagesDiscution.Modules;

public class GetMessagesDiscutionModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IGetMessagesDiscutionUseCase, GetMessagesDiscutionUseCase>();

        services.AddSingleton<GetMessagesDiscutionHandler>();
        services.AddSingleton<VerifyPermissionHandler>();
    }
}
