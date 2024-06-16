using System.Text.RegularExpressions;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Solidarize.Application.Interfaces.Services;

namespace Solidarize.Infraestructure.Services;

public class FileService : IFileService
{
    private BlobServiceClient blobServiceClient { get; set; }
    public FileService()
    {
        blobServiceClient = new BlobServiceClient(Environment.GetEnvironmentVariable("StorageAcountStringConection"), new BlobClientOptions());
    }

public (bool Sucess, string Id, Exception? e) SaveFile(string Blob, string Container, Domain.Enums.MessageFileType messageFileType)
{
    Guid Id = Guid.NewGuid();

    BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(Container);
    try
    {
        string base64WithoutPrefix = Regex.Replace(Blob, @"^data:.+;base64,", "");
        string mimeType = Blob.Split(';')[0].Split(':')[1];

        byte[] fileBytes = Convert.FromBase64String(base64WithoutPrefix);

        BlobClient blobClient = blobContainerClient.GetBlobClient(Id.ToString());

        BlobHttpHeaders headers = new BlobHttpHeaders();
        switch (messageFileType)
        {
            case Domain.Enums.MessageFileType.ImageJpeg:
                headers.ContentType = "image/jpeg";
                break;
            case Domain.Enums.MessageFileType.ImagePng:
                headers.ContentType = "image/png";
                break;
            case Domain.Enums.MessageFileType.VideoMp4:
                headers.ContentType = "video/mp4";
                break;
            case Domain.Enums.MessageFileType.Document:
                headers.ContentType = mimeType; 
                break;
        }

        using (var stream = new MemoryStream(fileBytes))
        {
            blobClient.Upload(stream, headers);
        }
        return (true, Id.ToString(), null);
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
