using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.Bundaries.PatchCompany;

public class PatchCompanyResponse
{
    public PatchCompanyResponse(Company? company)
    {
        this.company = company;
    }

    public Company? company {get; private set;}
}
