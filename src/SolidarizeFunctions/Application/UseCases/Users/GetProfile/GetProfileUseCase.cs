using Solidarize.Api.UseCases.Users.GetProfile;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.GetProfile.Handlers;

namespace Solidarize.Application.UseCases.Users.GetProfile;

public class GetProfileUseCase : IGetProfileUseCase
{
    private readonly ILogRepository logRepository;
    private readonly GetProfilePresenter outputPort;
    private readonly GetCompanyDBHandler handler;

    public GetProfileUseCase
    (ILogRepository logRepository, 
    GetProfilePresenter outputPort,
    GetCompanyDBHandler getCompanyDBHandler)
    {
        this.logRepository = logRepository;
        this.outputPort = outputPort;
        this.handler = getCompanyDBHandler;
    }
    public void Execute(GetProfileRequest request)
    {
       try
        {
            handler.ProcessRequest(request);
            outputPort.Standard(new(request.company));
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
