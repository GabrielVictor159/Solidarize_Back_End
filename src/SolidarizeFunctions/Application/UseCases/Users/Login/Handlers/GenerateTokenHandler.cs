using Azure.Core;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Application.UseCases.Users.Login.Handlers;

public class GenerateTokenHandler : Handler<LoginRequest>
{
    private readonly ITokenService tokenService;

    public GenerateTokenHandler(ITokenService tokenService)
    {
        this.tokenService = tokenService;
    }


    public override void ProcessRequest(LoginRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");

        request.Token = tokenService.Generate("USER", request.Company!.Id);
        
        sucessor?.ProcessRequest(request);
    }

}
