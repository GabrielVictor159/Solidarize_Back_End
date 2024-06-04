using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.GetProfile.Handlers;

public class GetCompanyDBHandler : Handler<GetProfileRequest>
{
    private readonly INotificationService notificationService;
    private readonly ICompanyRepository companyRepository;

    public GetCompanyDBHandler
    (INotificationService notificationService, 
    ICompanyRepository companyRepository)
    {
        this.notificationService = notificationService;
        this.companyRepository = companyRepository;
    }

    public override void ProcessRequest(GetProfileRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        var company = companyRepository.GetOne(request.Id);
        if(company==null)
        {
            notificationService.AddNotification("Company Not Found", "Não foi possivel encontrar uma empresa com esse Id");
            return;
        }
        request.company= company;
        sucessor?.ProcessRequest(request);
    }
}
