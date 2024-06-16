using Solidarize.Api.UseCases.MessageDiscution.GetMessagesDiscution;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Shipping.GetMessagesDiscution.Handlers;

namespace Solidarize.Application.UseCases.Shipping.GetMessagesDiscution;

public class GetMessagesDiscutionUseCase : IGetMessagesDiscutionUseCase
{
    private readonly ILogRepository logRepository;
    private readonly GetMessagesDiscutionPresenter outputPort;
    private readonly VerifyPermissionHandler handler;

    public GetMessagesDiscutionUseCase
    (ILogRepository logRepository, 
    GetMessagesDiscutionPresenter outputPort, 
    VerifyPermissionHandler verifyPermissionHandler,
    GetMessagesDiscutionHandler getMessagesDiscutionHandler)
    {
        verifyPermissionHandler.SetSucessor(getMessagesDiscutionHandler);
        
        this.logRepository = logRepository;
        this.outputPort = outputPort;
        this.handler = verifyPermissionHandler;
    }

    public void Execute(GetMessageDiscutionRequest request)
    {
        try
        {
            handler.ProcessRequest(request);
            outputPort.Standard(new(request.MessageDiscutions));
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
