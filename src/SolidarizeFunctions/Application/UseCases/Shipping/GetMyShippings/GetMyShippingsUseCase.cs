using Solidarize.Api.UseCases.Shipping.GetMyShippings;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Shipping.GetMyShippings.Handlers;

namespace Solidarize.Application.UseCases.Shipping.GetMyShippings;

public class GetMyShippingsUseCase : IGetMyShippingsUseCase
{
    private readonly ILogRepository logRepository;
    private readonly GetMyShippingsHandler handler;
    private readonly GetMyShippingsPresenter outputPort;

    public GetMyShippingsUseCase
    (ILogRepository logRepository,
    GetMyShippingsHandler handler,
    GetMyShippingsPresenter outputPort)
    {
        this.logRepository = logRepository;
        this.handler = handler;
        this.outputPort = outputPort;
    }
    public void Execute(GetMyShippingsRequest request)
    {
        try
        {
            handler.ProcessRequest(request);
            outputPort.Standard(new(request.Shippings));
        }
        catch (Exception ex)
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
