using System.Diagnostics;
using System.Security.Cryptography;
using System.Text;

namespace TechroseDemo
{
    public class PasswordHashing
    {
        static readonly int rounds = 200;

        public static bool PasswordHashCheck(PasswordHashModel p_modelPasswordHash)
        {
            byte[] salt = Convert.FromBase64String(p_modelPasswordHash.Salt);

            var hashedPassword = HashPassword(Encoding.UTF8.GetBytes(p_modelPasswordHash.PasswordToHash), salt, rounds);

            if (p_modelPasswordHash.HashedPassword == Convert.ToBase64String(hashedPassword))
            {
                return true;
            }

            return false;
        }

        public static PasswordHashModel PasswordHash(string password)
        {
            PasswordHashModel p_passwordHashModel = new();

            byte[] salt = GenerateSalt();

            p_passwordHashModel.Salt = Convert.ToBase64String(salt);

            var sw = new Stopwatch();
            sw.Start();

            byte[]? hashedPassword = HashPassword(Encoding.UTF8.GetBytes(password), salt, rounds);

            p_passwordHashModel.HashedPassword = Convert.ToBase64String(hashedPassword);
            sw.Stop();

            return p_passwordHashModel;
        }
        private static byte[] GenerateSalt()
        {
            using var rng = RandomNumberGenerator.Create();
            var uintBuffer = new byte[32];
            rng.GetBytes(uintBuffer);

            return uintBuffer;
        }

        private static byte[] HashPassword(byte[] hashed, byte[] salt, int rounds)
        {

            #pragma warning disable SYSLIB0041 // Type or member is obsolete
            using (Rfc2898DeriveBytes rfc2898DeriveBytes = new(password: hashed, salt: salt, iterations: rounds))
            {
                return rfc2898DeriveBytes.GetBytes(32);
            }
        }
    }
}
