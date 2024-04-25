using Newtonsoft.Json;
using Solidarize.Application.Interfaces.Services;
using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;

public class CreateRequestCompanyEnitityHandler : Handler<RequestRegisterCompanyRequest>
{
    private readonly INotificationService notificationService;

    public CreateRequestCompanyEnitityHandler(INotificationService notificationService)
    {
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(RequestRegisterCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType}");
        
        request.Company = new Company(request.CompanyName, "","",request.Description, request.LegalNature, request.LocationX, request.LocationY, false, null, DateTime.Now, DateTime.Now, request.CNPJ,request.Address,request.Telefone, 
        request.Email, Guid.NewGuid(), request.PasswordObject!.Id, request.PasswordObject);

        request.RequestCompany = new RequestCompany(Guid.NewGuid(), JsonConvert.SerializeObject(request.Company), DateTime.Now);

        if(!request.Company.IsValid)
        {
            notificationService.AddNotifications(request.Company.ValidationResult);
        }

        sucessor?.ProcessRequest(request);
    }
}
 