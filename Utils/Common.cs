using System.ComponentModel;

namespace TechroseDemo
{
    public static class Common
    {
        public static string ExceptionToString(Exception ex)
        {
            string result = "";

            try
            {
                if ( ex.Message != null )
                {
                    result = ex.Message.ToString();
                }
            }
            catch
            {

            }

            try
            {
                if ( ex.InnerException != null )
                {
                    result += " - Inner Exception : " + ex.InnerException.ToString();
                }
            }
            catch
            {

            }

            return result;
        }
    }
}
