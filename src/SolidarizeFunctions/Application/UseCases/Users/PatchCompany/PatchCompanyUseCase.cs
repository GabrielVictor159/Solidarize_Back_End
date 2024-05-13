using Solidarize.Api.UseCases.Users.PatchCompany;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers;

namespace Solidarize.Application.UseCases.Users.PatchCompany;

public class PatchCompanyUseCase : IPatchCompanyUseCase
{
    private readonly GetCompanyDBHandler getCompanyDBHandler;
    private readonly ILogRepository logRepository;
    private readonly PatchCompanyPresenter outputPort;

    public PatchCompanyUseCase
    (GetCompanyDBHandler getCompanyDBHandler,
    UpdateCompanyHandler updateCompanyHandler, 
    ILogRepository logRepository, 
    PatchCompanyPresenter outputPort)
    {
        getCompanyDBHandler.SetSucessor(updateCompanyHandler);
        
        this.getCompanyDBHandler = getCompanyDBHandler;
        this.logRepository = logRepository;
        this.outputPort = outputPort;
    }

    public void Execute(PatchCompanyRequest request)
    {
       try
        {
            getCompanyDBHandler.ProcessRequest(request);
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
