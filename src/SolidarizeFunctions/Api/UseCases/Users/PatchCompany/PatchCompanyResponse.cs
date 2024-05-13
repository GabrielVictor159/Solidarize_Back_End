namespace Solidarize.Api.UseCases.Users.PatchCompany;

public class PatchCompanyResponse
{
    public PatchCompanyResponse(Application.Bundaries.PatchCompany.PatchCompanyResponse? patchCompanyResponse)
    {
        if(patchCompanyResponse==null)
        {
            this.Sucess = false;
        }
    }
    public bool Sucess = true;
}
