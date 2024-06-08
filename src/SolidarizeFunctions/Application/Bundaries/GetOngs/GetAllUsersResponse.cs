using Solidarize.Domain.Models.Users;

namespace Solidarize.Application.Bundaries.GetOngs;

public class GetOngsResponse
{
    public GetOngsResponse(List<Company> companies)
    {
        Companies = companies;
    }

    public List<Company> Companies {get; private set;} = new();
}
