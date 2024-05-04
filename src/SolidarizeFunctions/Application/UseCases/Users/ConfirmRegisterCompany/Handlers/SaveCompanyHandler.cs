using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.ConfirmRegisterCompany.Handlers;

public class SaveCompanyHandler : Handler<ConfirmRegisterCompanyRequest>
{
    private readonly ICompanyRepository companyRepository;
    private readonly IRequestCompanyRepository requestCompanyRepository;

    public SaveCompanyHandler(ICompanyRepository companyRepository,
    IRequestCompanyRepository requestCompanyRepository)
    {
        this.companyRepository = companyRepository;
        this.requestCompanyRepository = requestCompanyRepository;
    }

    public override void ProcessRequest(ConfirmRegisterCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        companyRepository.Add(request.Company!);

        requestCompanyRepository.Delete(request.RequestCompany!);
        sucessor?.ProcessRequest(request);
    }
}
