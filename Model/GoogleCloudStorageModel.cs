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
            ImageExists = string.Empty;
        }

        public string ImageExists { get; set; }

        public string ImageName { get; set; }

        public IFormFile? FormFile { get; set; }
    }

    public class ImageExistsArgs
    { 
        public ImageExistsArgs()
        {
            ImageName = string.Empty;
        }

        public string ImageName { get; set; }
    }
}
