namespace Solidarize.Application.Interfaces.Services;

public interface IImagesServices
{
    (bool Sucess, string Id, Exception? e) SaveImage(string Blob, string Container);
    void DeleteImage(string BlobName, string Container);

}
