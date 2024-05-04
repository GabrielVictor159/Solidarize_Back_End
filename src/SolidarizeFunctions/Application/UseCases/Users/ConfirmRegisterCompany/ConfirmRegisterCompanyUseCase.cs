using Azure.Core;
using Solidarize.Application.Bundaries;
using Solidarize.Application.Bundaries.ConfirmRegisterCompany;
using Solidarize.Application.Interfaces.Repositories.Logs;
using Solidarize.Application.UseCases.Users.ConfirmRegisterCompany.Handlers;

namespace Solidarize.Application.UseCases.Users.ConfirmRegisterCompany;

public class ConfirmRegisterCompanyUseCase : IConfirmRegisterCompanyUseCase
{
    private readonly ILogRepository logRepository;
    private readonly SearchRequestCompanyHandler searchRequestCompanyHandler;
    private readonly IOutputPort<ConfirmRegisterCompanyResponse> outputPort;

    public ConfirmRegisterCompanyUseCase
    (ILogRepository logRepository, 
    SearchRequestCompanyHandler searchRequestCompanyHandler,
    CreateCompanyObjectHandler createCompanyObjectHandler,
    SearchCompanyHandler searchCompanyHandler,
    SaveCompanyHandler saveCompanyHandler, 
    IOutputPort<ConfirmRegisterCompanyResponse> outputPort)
    {
        searchRequestCompanyHandler
            .SetSucessor(createCompanyObjectHandler
            .SetSucessor(searchCompanyHandler
            .SetSucessor(saveCompanyHandler)));

        this.logRepository = logRepository;
        this.searchRequestCompanyHandler = searchRequestCompanyHandler;
        this.outputPort = outputPort;
    }

    public void Execute(ConfirmRegisterCompanyRequest request)
    {
        try
        {
            searchRequestCompanyHandler.ProcessRequest(request);
            outputPort.Standard(new(request.Company!.Id, request.Password!.Id));
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
