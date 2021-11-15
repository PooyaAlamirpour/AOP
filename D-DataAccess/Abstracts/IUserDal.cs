using System.Collections.Generic;
using Core.Concretes;
using Core.DataAccess;

namespace DataAccess.Abstracts
{
    public interface IUserDal : IEntityRepository<User>
    {
        List<OperationClaim> GetClaim(User user);

    }
}