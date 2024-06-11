using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.GetOngs.Handlers;

public class GetCompaniesDBHandler : Handler<GetOngsRequest>
{
    private readonly ICompanyRepository companyRepository;

    public GetCompaniesDBHandler(ICompanyRepository companyRepository)
    {
        this.companyRepository = companyRepository;
    }

    public override void ProcessRequest(GetOngsRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.Companies = companyRepository.GetByFilter((company)=>company.LegalNature==Domain.Enums.LegalNature.ONG);
        sucessor?.ProcessRequest(request);
    }
}
