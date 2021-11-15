using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.IdentityModel.JsonWebTokens;

namespace Core.Extensions
{
    public static class ClaimExtension
    {
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }
        
        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.FamilyName, name));
        }
        
        public static void AddNameIdentifier(this ICollection<Claim> claims, string nameIdentifier)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.NameId, nameIdentifier));
        }
        
        public static void AddRoles(this ICollection<Claim> claims, IEnumerable<string> roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }
    }
}