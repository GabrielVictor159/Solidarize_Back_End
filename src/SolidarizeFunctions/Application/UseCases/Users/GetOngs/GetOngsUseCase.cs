using Solidarize.Api.UseCases.Users.GetOngs;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.GetOngs.Handlers;

namespace Solidarize.Application.UseCases.Users.GetOngs;

public class GetOngsUseCase : IGetOngsUseCase
{
    private readonly ILogRepository logRepository;
    private readonly GetOngsPresenter outputPort;
    private readonly GetCompaniesDBHandler handler;

    public GetOngsUseCase
    (ILogRepository logRepository, 
    GetOngsPresenter outputPort,
    GetCompaniesDBHandler getCompaniesDBHandler)
    {
        this.logRepository = logRepository;
        this.outputPort = outputPort;
        this.handler = getCompaniesDBHandler;
    }

    public void Execute(GetOngsRequest request)
    {
        try
        {
            handler.ProcessRequest(request);
            outputPort.Standard(new(request.Companies));
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
