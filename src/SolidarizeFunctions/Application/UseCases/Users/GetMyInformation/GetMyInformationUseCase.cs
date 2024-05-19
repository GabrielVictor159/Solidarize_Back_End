using Solidarize.Api.UseCases.Users.GetMyInformation;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.GetMyInformation.Handlers;

namespace Solidarize.Application.UseCases.Users.GetMyInformation;

public class GetMyInformationUseCase : IGetMyInformationUseCase
{
    private readonly ILogRepository logRepository;
    private readonly GetMyInformationPresenter outputPort;
    private readonly GetCompanyDBHandler handler;

    public GetMyInformationUseCase
    (ILogRepository logRepository, 
    GetMyInformationPresenter outputPort, 
    GetCompanyDBHandler handler)
    {
        this.logRepository = logRepository;
        this.outputPort = outputPort;
        this.handler = handler;
    }

    public void Execute(GetMyInformationRequest request)
    {
        try
        {
            handler.ProcessRequest(request);
            outputPort.Standard(new(request.Company));
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
