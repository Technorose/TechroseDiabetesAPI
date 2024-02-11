namespace TechroseDemo
{
    public class GoogleCloudStorageModel
    {
    }

    public class GenerateDownloadImageUrlArgs
    {
        public GenerateDownloadImageUrlArgs()
        {
            FileName = string.Empty;
        }

        public string FileName { get; set; }
    }

    public class UploadImageArgs
    {
        public UploadImageArgs()
        {
            ImageName = "";
        }

        public string ImageName { get; set; }

        public IFormFile? FormFile { get; set; }
    }
}
