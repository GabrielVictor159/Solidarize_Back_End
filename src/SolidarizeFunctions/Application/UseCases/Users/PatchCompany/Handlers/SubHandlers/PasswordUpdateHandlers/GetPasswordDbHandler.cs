using Solidarize.Application.Interfaces.Repositories.Users;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.PasswordUpdateHandlers;

public class GetPasswordDbHandler : Handler<PatchCompanyRequest>
{
    private readonly IPasswordRepository passwordRepository;

    public GetPasswordDbHandler(IPasswordRepository passwordRepository)
    {
        this.passwordRepository = passwordRepository;
    }

    public override void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        request.PasswordObject = passwordRepository.GetOne(request.Company!.Idpassword);

        sucessor?.ProcessRequest(request);
    }
}
