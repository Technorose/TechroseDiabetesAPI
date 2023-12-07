namespace TechroseDemo
{
    public class PasswordHashModel
    {
        public PasswordHashModel()
        {
            PasswordToHash = string.Empty;
            Salt = string.Empty;
            HashedPassword = string.Empty;
        }

        public string PasswordToHash { get; set;}

        public string Salt { get; set;}

        public string HashedPassword { get; set;}

        public long ElapsedMilliSeconds { get; set;}
    }
}
