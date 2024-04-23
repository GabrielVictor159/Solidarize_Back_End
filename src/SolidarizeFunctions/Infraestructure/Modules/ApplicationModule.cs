using Microsoft.Extensions.DependencyInjection;
using Solidarize.Application.Interfaces.Repositories.Chat;
using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Domain.Modules;
using Solidarize.Helpers;
using Solidarize.Infraestructure.Database.Repositories.Chat;
using Solidarize.Infraestructure.Database.Repositories.Users;
using Solidarize.Infraestructure.Services;

namespace Solidarize.Infraestructure.Modules;

public class ApplicationModule : Module
{
    public override void Configure(IServiceCollection services)
    {
        AddServices(services);
        AddRepositories(services);
    }

    private void AddServices(IServiceCollection services) 
    {
        services.AddSingleton<ITokenService, TokenService>();
    }
    private void AddRepositories(IServiceCollection services) 
    {
        services.AddScoped<IChatRepository, ChatRepository>();
        services.AddScoped<IMessageRepository, MessageRepository>();
        services.AddScoped<ICompanyRepository, CompanyRepository>();
        services.AddScoped<IPasswordRepository, PasswordRepository>();
    }
}
