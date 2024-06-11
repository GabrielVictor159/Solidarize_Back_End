using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.Interfaces.Repositories.Chat;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.Interfaces.Repositories.Shipping;
using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Modules;
using Solidarize.Application.UseCases.Users.ConfirmRegisterCompany.Modules;
using Solidarize.Application.UseCases.Users.GetCompanys.Modules;
using Solidarize.Application.UseCases.Users.GetMyInformation.Modules;
using Solidarize.Application.UseCases.Users.GetOngs.Modules;
using Solidarize.Application.UseCases.Users.GetProfile.Modules;
using Solidarize.Application.UseCases.Users.Login.Modules;
using Solidarize.Application.UseCases.Users.PatchCompany.Modules;
using Solidarize.Application.UseCases.Users.RecoverPassword.Modules;
using Solidarize.Application.UseCases.Users.RequestRegisterCompany;
using Solidarize.Application.UseCases.Users.RequestRegisterCompany.Modules;
using Solidarize.Domain.Modules;
using Solidarize.Helpers;
using Solidarize.Infraestructure.Database.Map.Users;
using Solidarize.Infraestructure.Database.Repositories.Chat;
using Solidarize.Infraestructure.Database.Repositories.Logs;
using Solidarize.Infraestructure.Database.Repositories.Shipping;
using Solidarize.Infraestructure.Database.Repositories.Users;
using Solidarize.Infraestructure.Services;

namespace Solidarize.Infraestructure.Modules;

public class ApplicationModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        AddServices(services);
        AddRepositories(services);
        AddUseCases(services);
    }
    private void AddUseCases(IServiceCollection services)
    {
        new RequestRegisterCompanyModule().Configure(services);
        new ConfirmRegisterCompanyModule().Configure(services);
        new RecoverPasswordModule().Configure(services);
        new ConfirmRecoverPasswordModule().Configure(services);
        new LoginModule().Configure(services);
        new PatchCompanyModule().Configure(services);
        new GetMyInformationModule().Configure(services);
        new GetProfileModule().Configure(services);
        new GetOngsModule().Configure(services);
        new GetCompanysModule().Configure(services);
    }
    private void AddServices(IServiceCollection services) 
    {
        services.AddSingleton<ITokenService, TokenService>();
        services.AddSingleton<IImagesServices, ImagesServices>();
        services.AddSingleton<IEmailService, EmailService>();
    }
    private void AddRepositories(IServiceCollection services) 
    {
        services.AddSingleton<IChatRepository, ChatRepository>();
        services.AddSingleton<IMessageRepository, MessageRepository>();
        services.AddSingleton<ICompanyRepository, CompanyRepository>();
        services.AddSingleton<IPasswordRepository, PasswordRepository>();
        services.AddSingleton<IRequestCompanyRepository, RequestCompanyRepository>();
        services.AddSingleton<ILogRepository, LogRepository>();
        services.AddSingleton<IRequestRecoverPasswordRepository, RequestRecoverPasswordRepository>();
        services.AddSingleton<IAttachedFileRepository, AttachedFileRepository>();
        services.AddSingleton<IMessageDiscutionRepository, MessageDiscutionRepository>();
        services.AddSingleton<IShippingRepository, ShippingRepository>();
    }
}
