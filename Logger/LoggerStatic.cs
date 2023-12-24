namespace TechroseDemo
{
    public static class LoggerStatic
    {
        #region LogColumnNames
        public const string UserId = "UserId";
        public const string Details = "Details";
        public const string ErrorCode = "ErrorCode";
        public const string Token = "Token";
        public const string Exception = "Exception";
        #endregion

        #region LogStatus
        public const string LogTrigger = "{@function} Controller Triggered";
        public const string LogSuccess = "{@function} Controller Completed Successfully";
        public const string LogFail = "{@function} Controller Failed";
        public const string LogException = "Exception in {@function}: {@exception}";
        #endregion
    }
}
