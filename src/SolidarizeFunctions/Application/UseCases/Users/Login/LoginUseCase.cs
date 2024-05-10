using Solidarize.Application.Bundaries;
using Solidarize.Application.Bundaries.Login;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.Login.Handlers;

namespace Solidarize.Application.UseCases.Users.Login;

public class LoginUseCase : ILoginUseCase
{
    private readonly ILogRepository logRepository;
    private readonly LoginDbHandler loginDbHandler;
    private readonly IOutputPort<LoginResponse> outputPort;

    public LoginUseCase
    (ILogRepository logRepository, 
    IOutputPort<LoginResponse> outputPort,
    LoginDbHandler loginDbHandler,
    GenerateTokenHandler generateTokenHandler
    )
    {
        loginDbHandler.SetSucessor(generateTokenHandler);

        this.logRepository = logRepository;
        this.outputPort = outputPort;
        this.loginDbHandler = loginDbHandler;
    }

    public void Execute(LoginRequest request)
    {
        try
        {
           loginDbHandler.ProcessRequest(request);
           outputPort.Standard(new(request.Token));
        } 
        catch(Exception ex)
        {
            request.AddLog(Domain.Enums.LogType.ERROR, $"Occurring an error: {ex.Message ?? ex.InnerException?.Message}, stacktrace: {ex.StackTrace}");
            outputPort.Error(ex.Message!);
        }
        finally
        {
            logRepository.AddRange(request.Logs);
        }
    }

}
