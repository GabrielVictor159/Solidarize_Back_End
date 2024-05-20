using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Handlers;

public class SaveNewPasswordHandler : Handler<ConfirmRecoverPasswordRequest>
{
    private readonly IPasswordRepository passwordRepository;
    private readonly IRequestRecoverPasswordRepository requestRecoverPasswordRepository;

    public SaveNewPasswordHandler
    (IPasswordRepository passwordRepository, 
    IRequestRecoverPasswordRepository requestRecoverPasswordRepository)
    {
        this.passwordRepository = passwordRepository;
        this.requestRecoverPasswordRepository = requestRecoverPasswordRepository;
    }

    public override void ProcessRequest(ConfirmRecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        passwordRepository.Update(request.Company!.Password!);
        requestRecoverPasswordRepository.Delete(request.RequestRecoverPassword!);
        
        sucessor?.ProcessRequest(request);
    }
}
