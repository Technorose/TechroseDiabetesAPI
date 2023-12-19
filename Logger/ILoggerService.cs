namespace TechroseDemo
{
    public interface ILoggerService
    {
        void LogInformation(string message, string functionName);
        void LogInformation(string message, string token, string functionName);
        void LogInformation(string message, string token, int userId, string functionName);
        void LogWarning(string message, ResultModel resultModel, string functionName);
        void LogError(string message, Exception exception, ResultModel resultModel, string functionName);
    }
}
