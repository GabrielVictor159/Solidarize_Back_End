using Newtonsoft.Json;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.ConfirmRegisterCompany.Handlers;

public class CreateCompanyObjectHandler : Handler<ConfirmRegisterCompanyRequest>
{
    public override void ProcessRequest(ConfirmRegisterCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.Company = JsonConvert.DeserializeObject<Company>(request.RequestCompany!.Body);
        request.Password = request.Company!.Password;
        sucessor?.ProcessRequest(request);
    }
}
