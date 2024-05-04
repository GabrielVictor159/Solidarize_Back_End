using Solidarize.Application.Interfaces.Repositories.Users;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.ConfirmRegisterCompany.Handlers;

public class SearchRequestCompanyHandler : Handler<ConfirmRegisterCompanyRequest>
{
    private readonly IRequestCompanyRepository requestCompanyRepository;
    private readonly INotificationService notificationService;

    public SearchRequestCompanyHandler
    (IRequestCompanyRepository requestCompanyRepository, 
    INotificationService notificationService)
    {
        this.requestCompanyRepository = requestCompanyRepository;
        this.notificationService = notificationService;
    }

    public override void ProcessRequest(ConfirmRegisterCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        request.RequestCompany = requestCompanyRepository.GetOne(request.IdRequest);

        if(request.RequestCompany is null)
        {
            notificationService.AddNotification("Not Existing Request","Não há solicitação para criar uma empresa com este Id");
            return;
        }

        sucessor?.ProcessRequest(request);
    }
}
