using System;
using System.Collections.Generic;
using System.Linq;
using Core.Concretes;
using Core.DataAccess.EFCore;
using DataAccess.Abstracts;
using DataAccess.Concretes.EFCore.Contexts;

namespace DataAccess.Concretes.EFCore
{
    public class EfUserDal : EfCoreRepositoryBase<User, NorthwindContext>, IUserDal
    {
        public List<OperationClaim> GetClaim(User user)
        {
            using var context = new NorthwindContext();
            var result = from operationClaim in context.OperationClaim
                join userOperationClaim in context.UserOperationClaim
                    on operationClaim.Id equals userOperationClaim.OperationClaimId
                where userOperationClaim.UserId == user.Id
                select new OperationClaim
                {
                    Id = operationClaim.Id,
                    Name = operationClaim.Name
                };
            return result.ToList();
        }
    }
}