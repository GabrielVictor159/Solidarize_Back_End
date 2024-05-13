using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers;

public class GetCompanyDBHandler : Handler<PatchCompanyRequest>
{
    private readonly ICompanyRepository companyRepository;
    private readonly INotificationService notificationService;

    public GetCompanyDBHandler(ICompanyRepository companyRepository, INotificationService notificationService)
    {
        this.companyRepository = companyRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.Company = companyRepository.GetOne(request.IdUser);

        if(request.Company==null)
        {
            notificationService.AddNotification("Company Not Found", $"Não foi possivel encontrar uma empresa com o id {request.IdUser}");
            return;
        }
        sucessor?.ProcessRequest(request);
    }
}
