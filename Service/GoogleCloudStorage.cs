using Google.Apis.Auth.OAuth2;
using Google.Apis.Storage.v1.Data;
using Google.Cloud.Storage.V1;

namespace TechroseDemo
{
    public class GoogleCloudStorage : IGoogleCloudStorage
    {
        private readonly string? _bucketName;

        private readonly GoogleCredential _googleCredential;

        private readonly StorageClient _storageClient;

        public GoogleCloudStorage(IConfiguration configuration)
        {
            _googleCredential = GoogleCredential.FromFile(configuration.GetValue<string>("googleCredential:credentialFile"));
            _storageClient = StorageClient.Create(_googleCredential);
            _bucketName = configuration.GetValue<string>("googleCredential:bucketName");
        }

        public string GenerateDownloadImageUrl(GenerateDownloadImageUrlArgs args)
        {
            return $"https://storage.googleapis.com/{_bucketName}/{args.FileName}";
        }

        public async Task<bool> UploadImage(UploadImageArgs args)
        {
            #pragma warning disable CS8602 // Possible null reference assignment.
            Stream streamedFile = args.FormFile.OpenReadStream();

            var result = await _storageClient.UploadObjectAsync(_bucketName, args.ImageName, null, streamedFile);

            return !result.Id.Equals("");
        }
    }
}
