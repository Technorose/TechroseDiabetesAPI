namespace TechroseDemo
{
    public class ResultModel
    {
        public ResultModel()
        {
            Success = default(bool);
            ErrorCode = string.Empty;
            ErrorDescription = string.Empty;
            ErrorException = string.Empty;  
        }

        public bool Success { get; set; }

        public string ErrorCode { get; set; }

        public string ErrorDescription { get; set; }

        public string ErrorException { get; set; }
    }
}
