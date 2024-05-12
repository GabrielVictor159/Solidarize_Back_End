using Solidarize.Api.UseCases.Users.ConfirmRecoverPassword;
using Solidarize.Application.Bundaries;
using Solidarize.Application.Bundaries.ConfirmRecoverPassword;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.ConfirmRecoverPassword.Handlers;

namespace Solidarize.Application.UseCases.Users.ConfirmRecoverPassword;

public class ConfirmRecoverPasswordUseCase : IConfirmRecoverPasswordUseCase
{
    private readonly ILogRepository logRepository;
    private readonly SearchRequestRecoverPasswordHandler searchRequestRecoverPasswordHandler;
    private readonly ConfirmRecoverPasswordPresenter outputPort;

    public ConfirmRecoverPasswordUseCase
    (ILogRepository logRepository, 
    SearchRequestRecoverPasswordHandler searchRequestRecoverPasswordHandler,
    CreateNewPasswordHandler createNewPasswordHandler,
    SaveNewPasswordHandler saveNewPasswordHandler,
    ConfirmRecoverPasswordPresenter outputPort)
    {
        searchRequestRecoverPasswordHandler
        .SetSucessor(createNewPasswordHandler
        .SetSucessor(saveNewPasswordHandler));

        this.logRepository = logRepository;
        this.searchRequestRecoverPasswordHandler = searchRequestRecoverPasswordHandler;
        this.outputPort = outputPort;
    }

    public void Execute(ConfirmRecoverPasswordRequest request)
    {
        try
        {
            searchRequestRecoverPasswordHandler.ProcessRequest(request);
            outputPort.Standard(new(request.NewPassword, request.Company?.Password!));
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
