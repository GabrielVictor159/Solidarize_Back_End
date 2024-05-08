using Newtonsoft.Json;
using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Domain.Cryptography;

namespace Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Handlers;

public class CreateNewPasswordHandler : Handler<ConfirmRecoverPasswordRequest>
{
    private readonly ICompanyRepository companyRepository;
    private readonly IPasswordRepository passwordRepository;
    private readonly INotificationService notificationService;

    public CreateNewPasswordHandler
    (ICompanyRepository companyRepository, 
    IPasswordRepository passwordRepository,
    INotificationService notificationService)
    {
        this.companyRepository = companyRepository;
        this.passwordRepository = passwordRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(ConfirmRecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        request.Company = companyRepository.GetByFilter(e=>e.Email==request.Email).FirstOrDefault();
        if(request.Company is null)
        {
            notificationService.AddNotification("Not found Company","Não foi possivel encontrar uma empresa com o email desse processo");
            return;
        }
        request.Company.Password = passwordRepository.GetOne(request.Company.Idpassword)!;
        var EncryptPassword = request.NewPassword.PasswordEncryption();

        request.Company.Password
        .SetPasswordValue(EncryptPassword.Result, EncryptPassword.Method, request.NewPassword.Length, 
        CryptographyExtension.PasswordComplexityIndex(request.NewPassword));

        var latestPasswords = JsonConvert.DeserializeObject<List<string>>(request.Company.Password.LatestPasswords);

        if(latestPasswords!.Any(e=> e.Equals(EncryptPassword.Result)))
        {
            notificationService.AddNotification("Password Not Valid","Por favor adicione uma senha não utilizada anteriormente");
            return;
        }

        if(!request.Company.Password.IsValid)
        {
            notificationService.AddNotifications(request.Company.Password.ValidationResult);
            return;
        }
    
        sucessor?.ProcessRequest(request);
    }
}
