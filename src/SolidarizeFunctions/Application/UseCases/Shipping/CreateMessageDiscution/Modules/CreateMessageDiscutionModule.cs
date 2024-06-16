using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers;
using Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers.SubHandlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Modules;

public class CreateMessageDiscutionModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<ICreateMessageDiscutionUseCase, CreateMessageDiscutionUseCase>();

        services.AddSingleton<VerifyCreationHandler>();
        services.AddSingleton<ValidateDomainHandler>();
        services.AddSingleton<SaveMessageDiscutionHandler>();
        services.AddSingleton<SaveAttachedFilesHandler>();
    }
}
