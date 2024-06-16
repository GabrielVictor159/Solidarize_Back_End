using Solidarize.Application.Interfaces.Repositories.Shipping;
using Solidarize.Domain.Models.Shipping;

namespace Solidarize.Application.UseCases.Shipping.GetMessagesDiscution.Handlers;

public class GetMessagesDiscutionHandler : Handler<GetMessageDiscutionRequest>
{
    private readonly IMessageDiscutionRepository messageDiscutionRepository;
    private readonly IAttachedFileRepository attachedFileRepository;

    public GetMessagesDiscutionHandler
    (IMessageDiscutionRepository messageDiscutionRepository,
    IAttachedFileRepository attachedFileRepository)
    {
        this.messageDiscutionRepository = messageDiscutionRepository;
        this.attachedFileRepository = attachedFileRepository;
    }

    public override void ProcessRequest(GetMessageDiscutionRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        request.MessageDiscutions = messageDiscutionRepository.GetByFilter(e => e.IdShipping == request.IdShipping);
        List<MessageDiscution> messageDiscutions = new();
        foreach (var messageDiscution in request.MessageDiscutions)
        {
            var attachedFiles = attachedFileRepository.GetByFilter(f => f.IdMessageDiscution == messageDiscution.Id);
            messageDiscution.AttachedFiles = attachedFiles;
            messageDiscutions.Add(messageDiscution);
        }
        request.MessageDiscutions = messageDiscutions;
        sucessor?.ProcessRequest(request);
    }
}
