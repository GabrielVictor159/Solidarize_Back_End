using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.IconUpdateHandlers;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.ImagesUpdateHandlers;
using Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers.PasswordUpdateHandlers;

namespace Solidarize.Application.UseCases.Users.PatchCompany.Handlers.SubHandlers;

public class UpdateSubHandlersFactory 
{
    private readonly GetPasswordDbHandler getPasswordDbHandler;
    private readonly PersistNewImagesHandler persistNewImagesHandler;
    private readonly PersistNewIconHandler persistNewIconHandler;

    public UpdateSubHandlersFactory
    (GetPasswordDbHandler getPasswordDbHandler,
    UpdatePasswordHandler updatePasswordHandler,  
    PersistNewImagesHandler persistNewImagesHandler,
    RemoveOldImagesHandler removeOldImagesHandler,
    PersistNewIconHandler persistNewIconHandler,
    RemoveOldIconHandler removeOldIconHandler)
    {
        getPasswordDbHandler.SetSucessor(updatePasswordHandler);

        persistNewImagesHandler.SetSucessor(removeOldImagesHandler);

        persistNewIconHandler.SetSucessor(removeOldIconHandler);

        this.getPasswordDbHandler = getPasswordDbHandler;
        this.persistNewImagesHandler = persistNewImagesHandler;
        this.persistNewIconHandler = persistNewIconHandler;
    }

    public void ProcessRequest(PatchCompanyRequest request)
    {
        request.AddLog(Domain.Enums.LogType.PROCESS, $"The process arrived at the handler {this.GetType().FullName}");
        
        if(request.Icon!=null)
        {
            persistNewIconHandler.ProcessRequest(request);
        }

        if(request.Images!=null)
        {
            persistNewImagesHandler.ProcessRequest(request);
        }

        if(request.Password!=null)
        {
            getPasswordDbHandler.ProcessRequest(request);
        }
    }
}
