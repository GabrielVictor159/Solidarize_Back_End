using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Domain.Cryptography;
using Solidarize.Domain.Models.Users;
using Solidarize.Infraestructure.Database.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.PasswordUpdateHandlers;

public class UpdatePasswordHandler : Handler<PatchCompanyRequest>
{
    private readonly IPasswordRepository passwordRepository;
    private readonly INotificationService notificationService;

    public UpdatePasswordHandler(IPasswordRepository passwordRepository, INotificationService notificationService)
    {
        this.passwordRepository = passwordRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        var PasswordEncryption = request.Password!.PasswordEncryption();
        request.PasswordObject!.SetPasswordValue(PasswordEncryption.Result, PasswordEncryption.Method, request.Password!.Length, request.Password!.PasswordComplexityIndex());

        if(!request.PasswordObject.IsValid)
        {
            notificationService.AddNotifications(request.PasswordObject.ValidationResult);
            return;
        }

        passwordRepository.Update(request.PasswordObject);
        sucessor?.ProcessRequest(request);
    }
}
