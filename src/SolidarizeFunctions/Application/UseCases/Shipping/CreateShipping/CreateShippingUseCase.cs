using Solidarize.Api.UseCases.Shipping.CreateShipping;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Shipping.CreateShipping.Handlers;

namespace Solidarize.Application.UseCases.Shipping.CreateShipping;

public class CreateShippingUseCase : ICreateShippingUseCase
{
    private readonly ILogRepository logRepository;
    private readonly ValidateDomainShippingHandler handler;
    private readonly CreateShippingPresenter outputPort;

    public CreateShippingUseCase
    (ILogRepository logRepository,
    ValidateDomainShippingHandler handler,
    ShippingDBAnalyseHandler shippingDBAnalyseHandler,
    CreateShippingHandler createShippingHandler,
    CreateShippingPresenter outputPort)
    {
        handler
        .SetSucessor(shippingDBAnalyseHandler
        .SetSucessor(createShippingHandler));

        this.logRepository = logRepository;
        this.handler = handler;
        this.outputPort = outputPort;
    }
    public void Execute(CreateShippingRequest request)
    {
        try
        {
            handler.ProcessRequest(request);
            outputPort.Standard(new(request.Shipping));
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
