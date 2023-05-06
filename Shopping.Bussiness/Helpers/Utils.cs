using System.Security.Cryptography;
using System.Text;

namespace hoppingCart.Bussiness.Helpers
{
    public static class Utils
    {
        public static string GenerateHash( string input)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }

        public static bool CompareHash( string input, string hash)
        {
            using SHA256 sha256Hash = SHA256.Create();
            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder builder = new();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            string hashedInput = builder.ToString();

            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashedInput, hash) == 0;
        }
    }
}
