namespace Solidarize.Application.Interfaces.Services;

public interface IFileService
{
    (bool Sucess, string Id, Exception? e) SaveFile(string Blob, string Container, Domain.Enums.MessageFileType messageFileType);
    void DeleteImage(string BlobName, string Container);
}
