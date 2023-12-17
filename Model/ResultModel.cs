using System.Text.Json.Serialization;

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

        [JsonPropertyName("success")]
        public bool Success { get; set; }

        [JsonPropertyName("error_code")]
        public string ErrorCode { get; set; }

        [JsonPropertyName("error_description")]
        public string ErrorDescription { get; set; }

        [JsonPropertyName("error_exception")]
        public string ErrorException { get; set; }
    }
}
