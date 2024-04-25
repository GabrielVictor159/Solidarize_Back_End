using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;

public class SaveRequestCompanyHandler : Handler<RequestRegisterCompanyRequest>
{
    private readonly IRequestCompanyRepository requestCompanyRepository;

    public SaveRequestCompanyHandler(IRequestCompanyRepository requestCompanyRepository)
    {
        this.requestCompanyRepository = requestCompanyRepository;
    }

    public override void ProcessRequest(RequestRegisterCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType}");
        
        requestCompanyRepository.Add(request.RequestCompany!);

        sucessor?.ProcessRequest(request);
    }
}
