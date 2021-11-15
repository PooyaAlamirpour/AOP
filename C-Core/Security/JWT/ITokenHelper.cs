using System.Collections.Generic;
using Core.Authentication.JWT;
using Core.Concretes;

namespace Core.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationClaims);
    }
}