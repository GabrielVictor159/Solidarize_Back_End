using Solidarize.Api.UseCases.Users.GetCompanys;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.GetCompanys.Handlers;

namespace Solidarize.Application.UseCases.Users.GetCompanys;

public class GetCompanysUseCase : IGetCompanysUseCase
{
    private readonly ILogRepository logRepository;
    private readonly GetCompanysPresenter outputPort;
    private readonly SearchCompaniesHandler handler;

    public GetCompanysUseCase
    (ILogRepository logRepository, 
    GetCompanysPresenter outputPort,
    SearchCompaniesHandler getCompaniesDBHandler)
    {
        this.logRepository = logRepository;
        this.outputPort = outputPort;
        this.handler = getCompaniesDBHandler;
    }
    public void Execute(GetCompanysRequest request)
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
