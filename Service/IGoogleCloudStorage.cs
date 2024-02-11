namespace TechroseDemo
{
    public interface IGoogleCloudStorage
    {
        string GenerateDownloadImageUrl(GenerateDownloadImageUrlArgs args);

        Task<bool> UploadImage(UploadImageArgs args);
    }
}
