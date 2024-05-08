using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Handlers;

public class SaveNewPasswordHandler : Handler<ConfirmRecoverPasswordRequest>
{
    private readonly IPasswordRepository passwordRepository;

    public SaveNewPasswordHandler(IPasswordRepository passwordRepository)
    {
        this.passwordRepository = passwordRepository;
    }

    public override void ProcessRequest(ConfirmRecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        passwordRepository.Update(request.Company!.Password);
        
        sucessor?.ProcessRequest(request);
    }
}
