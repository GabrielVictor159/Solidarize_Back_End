using Solidarize.Api.UseCases.Users.RecoverPassword;
using Solidarize.Application.Bundaries;
using Solidarize.Application.Bundaries.RecoverPassword;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.RecoverPassword.Handlers;

namespace Solidarize.Application.UseCases.Users.RecoverPassword;

public class RecoverPasswordUseCase : IRecoverPasswordUseCase
{
    private readonly ILogRepository logRepository;
    private readonly SearchCompanyHandler searchCompanyHandler;
    private readonly RecoverPasswordPresenter outputPort;

    public RecoverPasswordUseCase
    (ILogRepository logRepository, 
    RecoverPasswordPresenter outputPort,
    SearchCompanyHandler searchCompanyHandler,
    CreateRequestRecoverPasswordHandler createRequestRecoverPasswordHandler,
    SendEmailRecoverPasswordHandler sendEmailRecoverPasswordHandler
    )
    {
        searchCompanyHandler
            .SetSucessor(createRequestRecoverPasswordHandler
            .SetSucessor(sendEmailRecoverPasswordHandler));

        this.logRepository = logRepository;
        this.searchCompanyHandler = searchCompanyHandler;
        this.outputPort = outputPort;
    }

    public void Execute(RecoverPasswordRequest request)
    {
        try
        {
            searchCompanyHandler.ProcessRequest(request);
            outputPort.Standard(new(request.RequestRecoverPassword!.Id));
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
