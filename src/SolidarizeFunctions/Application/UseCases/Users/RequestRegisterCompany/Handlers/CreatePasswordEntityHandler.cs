
using Solidarize.Application.Interfaces.Services;
using Solidarize.Domain.Cryptography;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;

public class CreatePasswordEntityHandler : Handler<RequestRegisterCompanyRequest>
{
    private readonly INotificationService notificationService;

    public CreatePasswordEntityHandler(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(RequestRegisterCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType}");
        
        var EncryptPassword = request.Password.PasswordEncryption();
        request.PasswordObject = new Password(Guid.NewGuid(), DateTime.Now, "[]",EncryptPassword.Method, request.Password.Length,request.Password.PasswordComplexityIndex(),EncryptPassword.Result);

        if(!request.PasswordObject.IsValid)
        {
            notificationService.AddNotifications(request.PasswordObject.ValidationResult);
        }

        sucessor?.ProcessRequest(request);
    }
}
