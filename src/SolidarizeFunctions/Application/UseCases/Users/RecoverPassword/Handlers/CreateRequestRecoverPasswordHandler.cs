using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.RecoverPassword.Handlers;

public class CreateRequestRecoverPasswordHandler : Handler<RecoverPasswordRequest>
{
    private readonly IRequestRecoverPasswordRepository requestRecoverPasswordRepository;

    public CreateRequestRecoverPasswordHandler(IRequestRecoverPasswordRepository requestRecoverPasswordRepository)
    {
        this.requestRecoverPasswordRepository = requestRecoverPasswordRepository;
    }

    public override void ProcessRequest(RecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        request.RequestRecoverPassword = new(Guid.NewGuid(), request.Email, DateTime.Now);
        
        requestRecoverPasswordRepository.Add(request.RequestRecoverPassword);

        sucessor?.ProcessRequest(request);
    }
}
