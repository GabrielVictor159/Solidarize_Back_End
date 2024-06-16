using Solidarize.Api.UseCases.MessageDiscution.CreateMessageDiscution;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers;
using Solidarize.Application.UseCases.Shipping.CreateMessageDiscution.Handlers.SubHandlers;

namespace Solidarize.Application.UseCases.Shipping.CreateMessageDiscution;

public class CreateMessageDiscutionUseCase : ICreateMessageDiscutionUseCase
{
    private readonly ILogRepository logRepository;
    private readonly VerifyCreationHandler handler;
    private readonly CreateMessageDiscutionPresenter outputPort;

    public CreateMessageDiscutionUseCase
    (ILogRepository logRepository, 
    CreateMessageDiscutionPresenter presenter,
    VerifyCreationHandler verifyCreationHandler,
    ValidateDomainHandler validateDomainHandler,
    SaveAttachedFilesHandler saveAttachedFilesHandler,
    SaveMessageDiscutionHandler saveMessageDiscutionHandler)
    {
        verifyCreationHandler
        .SetSucessor(validateDomainHandler
        .SetSucessor(saveMessageDiscutionHandler));
        
        this.logRepository = logRepository;
        this.handler = verifyCreationHandler;
        this.outputPort = presenter;
    }
    public void Execute(CreateMessageDiscutionRequest request)
    {
        try
        {
            handler.ProcessRequest(request);
            outputPort.Standard(new(request.MessageDiscutionOutput, request.AttachedFilesOutput));
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
