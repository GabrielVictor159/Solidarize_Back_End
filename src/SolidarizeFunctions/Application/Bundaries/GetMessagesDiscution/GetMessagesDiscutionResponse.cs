using Solidarize.Domain.Models.Shipping;

namespace Solidarize.Application.Bundaries.GetMessagesDiscution;

public class GetMessagesDiscutionResponse
{
    public GetMessagesDiscutionResponse(List<MessageDiscution> messageDiscutions)
    {
        MessageDiscutions = messageDiscutions;
    }

    public List<MessageDiscution> MessageDiscutions {get; private set;} =new();
}
