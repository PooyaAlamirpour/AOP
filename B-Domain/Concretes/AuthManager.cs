using Core.Authentication.JWT;
using Core.Concretes;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.ViewModels.Results;
using Domain.Abstracts;
using Domain.Constances;
using Entities.DTO;

namespace Domain.Concretes
{
    public class AuthManager : IAuthService
    {
        private readonly IUserService _userService;
        private readonly ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<User> Register(UserForRegisterDto registerDto, string password)
        {
            var (passwordHash, passwordSalt) = HashingHelper.CreatePasswordHash(password);
            var user = new User
            {
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            
            return new SuccessDataResult<User>(user, Messages.UserIsRegistered);
        }

        public IDataResult<User> Login(UserForLoginDto loginDto)
        {
            var user = _userService.GetByEmail(loginDto.Email);
            if (user is null)
            {
                return  new ErrorDataResult<User>(Messages.UserIsNotFound);
            }

            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordSalt, user.PasswordHash))
            {
                return  new ErrorDataResult<User>(Messages.PasswordError);
            }
            
            return new SuccessDataResult<User>(user, Messages.SuccessfullyLogin);
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email) is not null)
            {
                return new ErrorResult(Messages.UserAlreadyExists);
            }

            return new SuccessResult();
        }
        
        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claim = _userService.GetClaims(user);
            var accessToken = _tokenHelper.CreateToken(user, claim);
            return new SuccessDataResult<AccessToken>(accessToken);
        }
    }
}