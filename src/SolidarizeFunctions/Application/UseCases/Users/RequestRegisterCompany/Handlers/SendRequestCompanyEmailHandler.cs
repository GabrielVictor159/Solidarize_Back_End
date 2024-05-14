using Solidarize.Application.Interfaces.Services;
using Solidarize.Application.Resources.Emails.ConfirmUser;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;

public class SendRequestCompanyEmailHandler : Handler<RequestRegisterCompanyRequest>
{
    private readonly IEmailService emailService;

    public SendRequestCompanyEmailHandler(IEmailService emailService)
    {
        this.emailService = emailService;
    }

    public override void ProcessRequest(RequestRegisterCompanyRequest request)
    {
       request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
       
       emailService.SendEmail(request.Email,"Solidarize Confirmação de Usuário",ConfirmUserEmail.Email(Environment.GetEnvironmentVariable("Front_URL")!+$"/ConfirmUser/{request.RequestCompany!.Id}"));

       sucessor?.ProcessRequest(request);
    }
}
