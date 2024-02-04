using System.Security.Claims;
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

    public class TokenCreateModelArgs
    {
        public TokenCreateModelArgs()
        {
            Claims = new Claim[0];
        }

        public Claim[] Claims { get; set; }
    }

    public class TokenCreateModelResult
    {
        public TokenCreateModelResult()
        {
            Token = string.Empty;
        }

        public string Token { get; set; }
    }

    public class TokenDecodeModelArgs
    {
        public TokenDecodeModelArgs()
        {
            AuthorizationToken = string.Empty;
        }

        public string AuthorizationToken { get; set; }
    }

    public class TokenDecodeModelResult
    {
        public TokenDecodeModelResult()
        {
            Issuer = string.Empty;
            Audience = new List<string>();
            Claims = new Dictionary<string, string>();
            SignatureAlgorithm = string.Empty;
        }

        public string Issuer { get; set; }

        public string SignatureAlgorithm { get; set; }

        public List<string> Audience { get; set; }

        public Dictionary<string, string> Claims { get; set; }
    }
}
