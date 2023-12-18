namespace TechroseDemo
{
    public interface ILoggerService
    {
        void LogInformation(string message);
        void LogInformation(string message, string token);
        void LogInformation(string message, string token, int userId);
        void LogWarning(string message, ResultModel resultModel);
        void LogError(string message, Exception exception, ResultModel resultModel);
    }
}
