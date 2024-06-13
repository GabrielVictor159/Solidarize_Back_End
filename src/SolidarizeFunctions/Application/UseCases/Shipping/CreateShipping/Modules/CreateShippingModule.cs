using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Shipping.CreateShipping.Handlers;
using Solidarize.Domain.Modules;
namespace Solidarize.Application.UseCases.Shipping.CreateShipping.Modules;

public class CreateShippingModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<ICreateShippingUseCase, CreateShippingUseCase>();

        services.AddSingleton<CreateShippingHandler>();
        services.AddSingleton<ShippingDBAnalyseHandler>();
        services.AddSingleton<ValidateDomainShippingHandler>();
    }
}
