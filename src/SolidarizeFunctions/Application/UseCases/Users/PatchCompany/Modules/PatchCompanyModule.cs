using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.IconUpdateHandlers;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.ImagesUpdateHandlers;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.PasswordUpdateHandlers;
using Solidarize.Domain.Modules;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Modules;

public class PatchCompanyModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        services.AddTransient<IPatchCompanyUseCase, PatchCompanyUseCase>();

        services.AddSingleton<PersistNewIconHandler>();
        services.AddSingleton<RemoveOldIconHandler>();
        services.AddSingleton<PersistNewImagesHandler>();
        services.AddSingleton<RemoveOldImagesHandler>();
        services.AddSingleton<GetPasswordDbHandler>();
        services.AddSingleton<UpdatePasswordHandler>();
        services.AddSingleton<GetCompanyDBHandler>();
        services.AddSingleton<UpdateCompanyHandler>();
        services.AddSingleton<UpdateSubHandlersFactory>();

    }
}
