namespace TechroseDemo
{
    public class TokenCheckModelArgs
    { 
        public TokenCheckModelArgs() 
        {
            ClientTime = default(DateTime);
        }

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

        public DateTime ClientTime { get; set; }

        public DateTime ServerTime { get; set; }

        public ResultModel Result { get; set; }
    }
}
