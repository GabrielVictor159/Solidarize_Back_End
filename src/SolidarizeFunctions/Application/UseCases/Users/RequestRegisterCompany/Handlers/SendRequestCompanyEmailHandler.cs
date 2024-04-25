namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;

public class SendRequestCompanyEmailHandler : Handler<RequestRegisterCompanyRequest>
{

    public override void ProcessRequest(RequestRegisterCompanyRequest request)
    {
       request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType}");
       
       sucessor?.ProcessRequest(request);
    }
}
