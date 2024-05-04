using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;

public class SearchCompanyHandler : Handler<RequestRegisterCompanyRequest>
{
    private readonly ICompanyRepository companyRepository;
    private readonly INotificationService notificationService;

    public SearchCompanyHandler(ICompanyRepository companyRepository, INotificationService notificationService)
    {
        this.companyRepository = companyRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(RequestRegisterCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        var resultSearchCompanyName = companyRepository.GetByFilter(e=>e.CompanyName.ToLower()==request.Company!.CompanyName.ToLower() && e.LegalNature == request.Company!.LegalNature);
        if(resultSearchCompanyName.Any())
        {
            notificationService.AddNotification("Existing CompanyName", "Já existe empresa com mesmo nome e natureza jurídica");
            return;
        }

        var resultSearchEmail = companyRepository.GetByFilter(e=>e.Email == request.Company!.Email);
        
        if(resultSearchEmail.Any())
        {
            notificationService.AddNotification("Existing Email", "Já existe uma empresa com o mesmo email");
            return;
        }

        sucessor?.ProcessRequest(request);
    }
}
