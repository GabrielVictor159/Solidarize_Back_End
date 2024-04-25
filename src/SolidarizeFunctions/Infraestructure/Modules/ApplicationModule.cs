using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.Interfaces.Repositories.Chat;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Application.UseCases.Users.RequestRegisterCompany;
using Solidarize.Application.UseCases.Users.RequestRegisterCompany.Modules;
using Solidarize.Domain.Modules;
using Solidarize.Helpers;
using Solidarize.Infraestructure.Database.Repositories.Chat;
using Solidarize.Infraestructure.Database.Repositories.Logs;
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
    }
    private void AddServices(IServiceCollection services) 
    {
        services.AddSingleton<ITokenService, TokenService>();
    }
    private void AddRepositories(IServiceCollection services) 
    {
        services.AddSingleton<IChatRepository, ChatRepository>();
        services.AddSingleton<IMessageRepository, MessageRepository>();
        services.AddSingleton<ICompanyRepository, CompanyRepository>();
        services.AddSingleton<IPasswordRepository, PasswordRepository>();
        services.AddSingleton<IRequestCompanyRepository, RequestCompanyRepository>();
        services.AddSingleton<ILogRepository, LogRepository>();
    }
}
