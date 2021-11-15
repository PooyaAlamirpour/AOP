using Microsoft.IdentityModel.Tokens;

namespace Core.Security.Encryption
{
    public class SigningCredentialHelper
    {
        public static SigningCredentials CreateSigningCredential(SecurityKey securityKey)
        {
            return new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        }
    }
}