using Solidarize.Application.Interfaces.Services;
using Solidarize.Application.Resources.Emails.RecoverPassword;

namespace Solidarize.Application.UseCases.Users.RecoverPassword.Handlers;

public class SendEmailRecoverPasswordHandler : Handler<RecoverPasswordRequest>
{
    private readonly IEmailService emailService;

    public SendEmailRecoverPasswordHandler(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    public override void ProcessRequest(RecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        emailService.SendEmail(request.Email,"Solidarize Recuperação de senha",RecoverPasswordEmail.Email(Environment.GetEnvironmentVariable("Front_URL")!+$"/RecoverPassword/{request.RequestRecoverPassword!.Id}"));

        sucessor?.ProcessRequest(request);
    }
}
