using System.Text.Json.Serialization;

namespace TechroseDemo
{
    public class TokenCheckModelArgs
    { 
        public TokenCheckModelArgs() 
        {
            ClientTime = default(DateTime);
        }

        [JsonPropertyName("client_time")]
        public DateTime ClientTime { get; set; }
    }

    public class TokenCheckModelResult
    {
        public TokenCheckModelResult()
        {
            ClientTime = default(DateTime);
            ServerTime = default(DateTime);
            Result = new ResultModel();
        }

        [JsonPropertyName("client_time")]
        public DateTime ClientTime { get; set; }

        [JsonPropertyName("server_time")]
        public DateTime ServerTime { get; set; }

        public ResultModel Result { get; set; }
    }
}
