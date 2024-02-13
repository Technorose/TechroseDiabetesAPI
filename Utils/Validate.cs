using System.Text.RegularExpressions;

namespace TechroseDemo
{
    public class Validate
    {
        public static bool ValidateEmail(string email)
        {
            if(email.Equals(null) || email.Trim().Equals(""))
            {
                return false;
            }

            Regex validEmail = new Regex("^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\\.[a-zA-Z]{2,}$");

            return validEmail.IsMatch(email);
        }
    }
}
