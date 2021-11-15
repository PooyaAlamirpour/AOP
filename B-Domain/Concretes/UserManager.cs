using System.Collections.Generic;
using Core.Concretes;
using DataAccess.Abstracts;
using Domain.Abstracts;

namespace Domain.Concretes
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaim(user);
        }

        public void Add(User user)
        {
            _userDal.Add(user);
        }

        public User GetByEmail(string email)
        {
            return _userDal.Get(x => x.Email.Contains(email));
        }
    }
}