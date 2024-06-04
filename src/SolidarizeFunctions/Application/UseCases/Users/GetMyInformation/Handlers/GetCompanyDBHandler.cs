using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.GetMyInformation.Handlers;

public class GetCompanyDBHandler : Handler<GetMyInformationRequest>
{
    private readonly ICompanyRepository companyRepository;
    private readonly INotificationService notificationService;

    public GetCompanyDBHandler
    (ICompanyRepository companyRepository, 
    INotificationService notificationService)
    {
        this.companyRepository = companyRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(GetMyInformationRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.Company=companyRepository.GetOne(request.Id);
        if(request.Company==null)
        {
            notificationService.AddNotification("Company Not Found",$"Não foi possivel encontrar a compania com o Id={request.Id}");
            return;
        }
        sucessor?.ProcessRequest(request);
    }
}
