using Microsoft.AspNetCore.Mvc;

namespace TechroseDemo
{
    public class HeaderModelArgs
    {
        public HeaderModelArgs()
        {
            Authorization = string.Empty;
        }

        [FromHeader(Name = "Authorization")]
        public string Authorization { get; set; }
    }
}
