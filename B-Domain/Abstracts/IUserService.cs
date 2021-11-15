using System.Collections.Generic;
using Core.Concretes;

namespace Domain.Abstracts
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        void Add(User user);
        User GetByEmail(string email);
    }
}