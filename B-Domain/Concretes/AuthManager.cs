using Core.Authentication.JWT;
using Core.Concretes;
using Core.Security.Hashing;
using Core.Security.JWT;
using Core.ViewModels.Results;
using Domain.Abstracts;
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
            return new SuccessDataResult<User>(user, "User is registered.");
        }

        public IDataResult<User> Login(UserForLoginDto loginDto)
        {
            var user = _userService.GetByEmail(loginDto.Email);
            if (user is null)
            {
                return  new ErrorDataResult<User>("User not found.");
            }

            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, user.PasswordSalt, user.PasswordHash))
            {
                return  new ErrorDataResult<User>("Password error.");
            }
            
            return new SuccessDataResult<User>(user, "Successful login");
        }

        public IResult UserExist(string email)
        {
            if (_userService.GetByEmail(email) is not null)
            {
                return new ErrorResult("User already exit.");
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