using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.RecoverPassword.Handlers;

public class SearchCompanyHandler : Handler<RecoverPasswordRequest>
{
    private readonly ICompanyRepository companyRepository;
    private readonly INotificationService notificationService;

    public SearchCompanyHandler(ICompanyRepository companyRepository, INotificationService notificationService)
    {
        this.companyRepository = companyRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(RecoverPasswordRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.Company = companyRepository.GetByFilter(e=>e.Email==request.Email).FirstOrDefault();

        if(request.Company is null)
        {
            notificationService.AddNotification("Not Exist Company", "Não existe uma empresa com esse email");
            return;
        }
        sucessor?.ProcessRequest(request);
    }
}
