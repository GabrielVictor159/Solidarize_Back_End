using Solidarize.Api.UseCases.Users.RequestRegisterCompany;
using Solidarize.Application.Bundaries;
using Solidarize.Application.Bundaries.RequestRegisterCompany;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.RequestRegisterCompany.Handlers;

namespace Solidarize.Application.UseCases.Users.RequestRegisterCompany;

public class RequestRegisterCompanyUseCase : IRequestRegisterCompanyUseCase
{
    private readonly ILogRepository logRepository;
    private readonly CreatePasswordEntityHandler createPasswordEntityHandler;
    private readonly RequestRegisterCompanyPresenter outputPort;

    public RequestRegisterCompanyUseCase
    (ILogRepository logRepository, 
    RequestRegisterCompanyPresenter outputPort,
    CreatePasswordEntityHandler createPasswordEntityHandler,
    CreateRequestCompanyEnitityHandler createRequestCompanyEnitityHandler,
    SendRequestCompanyEmailHandler sendRequestCompanyEmailHandler,
    SaveRequestCompanyHandler saveRequestCompanyHandler,
    SearchCompanyHandler searchCompanyHandler)
    {
        this.logRepository = logRepository;

        createPasswordEntityHandler
        .SetSucessor(createRequestCompanyEnitityHandler
        .SetSucessor(searchCompanyHandler
        .SetSucessor(sendRequestCompanyEmailHandler
        .SetSucessor(saveRequestCompanyHandler))));

        this.createPasswordEntityHandler = createPasswordEntityHandler;
        this.outputPort = outputPort;
    }

    public void Execute(RequestRegisterCompanyRequest request)
    {
        try
        {
            createPasswordEntityHandler.ProcessRequest(request);
            outputPort.Standard(new(request.RequestCompany!=null ? request.RequestCompany.Id : Guid.Empty));
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
