using Google.Apis.Auth.OAuth2;
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

        public string GenerateDownloadImageUrl(string folderName, string fileName)
        {
            return $"https://storage.googleapis.com/{_bucketName}/{folderName}/{fileName}";
        }
    }
}
