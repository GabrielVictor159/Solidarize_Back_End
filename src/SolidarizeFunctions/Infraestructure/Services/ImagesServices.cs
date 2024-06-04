using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Infraestructure.Services;

public class ImagesServices : IImagesServices
{
    private BlobServiceClient blobServiceClient { get; set; }
    public ImagesServices()
    {
        blobServiceClient = new BlobServiceClient(Environment.GetEnvironmentVariable("StorageAcountStringConection"), new BlobClientOptions());
    }
    public (bool Sucess, string Id, Exception? e) SaveImage(string Blob, string Container)
    {
        Guid Id = Guid.NewGuid();

        BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(Container);
        try
        {
            string base64WithoutPrefix = Blob.Replace("data:image/jpeg;base64,", "").Replace("data:image/png;base64,", "");

            byte[] imageBytes = Convert.FromBase64String(base64WithoutPrefix);

            BlobClient blobClient = blobContainerClient.GetBlobClient(Id.ToString());
            BlobHttpHeaders headers = new BlobHttpHeaders
            {
                ContentType = "image/png"
            };

            using (var stream = new MemoryStream(imageBytes))
            {
                blobClient.Upload(stream, headers);
            }
            return (true, Id.ToString() + ".png", null);
        }
        catch (Exception E)
        {
            return (false, "", E);
        }
    }

    public void DeleteImage(string blobName, string containerName)
    {
        BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);

        string blobNameWithoutExtension = Path.GetFileNameWithoutExtension(blobName);

        BlobClient blobClient = blobContainerClient.GetBlobClient(blobNameWithoutExtension);
        blobClient.DeleteIfExists();
    }

}
