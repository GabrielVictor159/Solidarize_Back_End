namespace Solidarize.Application.UseCases.Users.RecoverPassword.Handlers;

public class SendEmailRecoverPasswordHandler : Handler<RecoverPasswordRequest>
{
    public override void ProcessRequest(RecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        sucessor?.ProcessRequest(request);
    }
}
