using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Domain.Cryptography;

namespace Solidarize.Application.UseCases.Users.Login.Handlers;

public class LoginDbHandler : Handler<LoginRequest>
{
    private readonly ICompanyRepository companyRepository;
    private readonly IPasswordRepository passwordRepository;
    private readonly INotificationService notificationService;

    public LoginDbHandler
    (ICompanyRepository companyRepository, 
    IPasswordRepository passwordRepository,
    INotificationService notificationService)
    {
        this.companyRepository = companyRepository;
        this.passwordRepository = passwordRepository;
        this.notificationService = notificationService;
    }


    public override void ProcessRequest(LoginRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.Company = companyRepository.GetByFilter(e=>e.Email==request.Email).FirstOrDefault();
        if(request.Company is null)
        {
            notificationService.AddNotification("Company Not found", "Credênciais incorretas");
            return;
        }
        var passwordEncryption = request.Password.PasswordEncryption();

        request.PasswordUser = passwordRepository
        .GetByFilter(e=>e.PasswordValue == passwordEncryption.Result && e.Id==request.Company.Idpassword)
        .FirstOrDefault();

        if(request.PasswordUser is null)
        {
            notificationService.AddNotification("Company Not found", "Credênciais incorretas");
            return;
        }
        
        sucessor?.ProcessRequest(request);
    }

}
