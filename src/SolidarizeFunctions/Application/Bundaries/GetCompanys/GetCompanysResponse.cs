using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.Bundaries.GetCompanys;

public class GetCompanysResponse
{
    public GetCompanysResponse(List<Company> companies)
    {
        Companies = companies;
    }

    public List<Company> Companies { get; private set; } = new();
}
