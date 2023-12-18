
using Serilog.Context;

namespace TechroseDemo
{
    public class LoggerService : ILoggerService
    {

        public void LogInformation(string message)
        {
            Serilog.Log.Information(message);
        }

        public void LogInformation(string message, string token)
        {
            LogContext.PushProperty(LogColumnNames.Token, token);
            Serilog.Log.Information(message);
        }

        public void LogInformation(string message, string token, int userId)
        {
            LogContext.PushProperty(LogColumnNames.UserId, userId);
            LogContext.PushProperty(LogColumnNames.Token, token);
            Serilog.Log.Information(message);
        }

        public void LogError(string message, Exception exception, ResultModel resultModel)
        {
            LogContext.PushProperty(LogColumnNames.Exception, resultModel.ErrorException);
            LogContext.PushProperty(LogColumnNames.ErrorCode, resultModel.ErrorCode);
            LogContext.PushProperty(LogColumnNames.Details, resultModel.ErrorDescription);
            Serilog.Log.Error(message, exception);
        }

        public void LogWarning(string message, ResultModel resultModel)
        {
            LogContext.PushProperty(LogColumnNames.Exception, resultModel.ErrorException);
            LogContext.PushProperty(LogColumnNames.ErrorCode, resultModel.ErrorCode);
            LogContext.PushProperty(LogColumnNames.Details, resultModel.ErrorDescription);
            Serilog.Log.Warning(message);
        }
    }
}
