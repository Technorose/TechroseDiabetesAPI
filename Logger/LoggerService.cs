using Serilog;
using Serilog.Context;

namespace TechroseDemo
{
    public class LoggerService : ILoggerService
    {

        #region Public Methods
        public void LogInformation(string message, string functionName)
        {
            Log.Information(message, functionName);
        }

        public void LogInformation(string message, string token, string functionName)
        {
            LogContext.PushProperty(LoggerStatic.Token, token);
            Log.Information(message, functionName);
        }

        public void LogInformation(string message, string token, int userId, string functionName)
        {
            LogContext.PushProperty(LoggerStatic.UserId, userId);
            LogContext.PushProperty(LoggerStatic.Token, token);
            Log.Information(message, functionName);
        }

        public void LogError(string message, Exception exception, ResultModel resultModel, string functionName)
        {
            PushProperty(resultModel);
            Log.Error(message, exception, functionName);
        }

        public void LogWarning(string message, ResultModel resultModel, string functionName)
        {
            PushProperty(resultModel);
            Log.Warning(message, functionName);
        }
        #endregion

        #region Private Methods
        private static void PushProperty(ResultModel resultModel)
        {
            LogContext.PushProperty(LoggerStatic.Exception, resultModel.ErrorException);
            LogContext.PushProperty(LoggerStatic.ErrorCode, resultModel.ErrorCode);
            LogContext.PushProperty(LoggerStatic.Details, resultModel.ErrorDescription);
        }
        #endregion
    }
}
