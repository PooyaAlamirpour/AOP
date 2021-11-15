using Core.Authentication.JWT;
using Core.Concretes;
using Core.ViewModels.Results;
using Entities.DTO;

namespace Domain.Abstracts
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto registerDto, string password);
        IDataResult<User> Login(UserForLoginDto loginDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}