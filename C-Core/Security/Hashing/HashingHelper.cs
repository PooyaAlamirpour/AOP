using System.Linq;
using System.Text;

namespace Core.Security.Hashing
{
    public class HashingHelper
    {
        public static (byte[] passwordHash, byte[] passwordSalt) CreatePasswordHash(string password)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512();
            return (hmac.ComputeHash(Encoding.UTF8.GetBytes(password)), hmac.Key);
        }
        
        public static bool VerifyPasswordHash(string password, byte[] passwordSalt, byte[] passwordHash)
        {
            using var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            return !computedHash.Where((t, i) => t != passwordHash[i]).Any();
        }
    }
}