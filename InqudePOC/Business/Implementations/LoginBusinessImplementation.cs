using InqudePOC.Configurations;
using InqudePOC.Data.VO;
using InqudePOC.Repository;
using InqudePOC.Services;
using InqudePOC.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace InqudePOC.Business.Implementations
{
    public class LoginBusinessImplementation : ILoginBusiness
    {
        private const string DATE_FORMAT = "yyyy-MM-dd HH:mm:ss";
        private TokenConfiguration _configuration;

        private IUserRepository _repository;
        private readonly ITokenService _tokenService;

        public LoginBusinessImplementation(TokenConfiguration configuration, IUserRepository repository, ITokenService tokenService)
        {
            _configuration = configuration;
            _repository = repository;
            _tokenService = tokenService;
        }

        public TokenVO ValidadeCredentials(UserVO userCredentials)
        {
            var user = _repository.ValidateCredentials(userCredentials);
            var User1 = new User();
            
            if (user == null)
            {
                Console.WriteLine("User inside -------"+user);
                return null;
            }

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                new Claim(JwtRegisteredClaimNames.UniqueName, "sdsdsdsd")
            };

            var acessToken = _tokenService.GenerateAcessToken(claims);
            var refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;
            user.RefreshTokenExpiryTime = DateTime.Now.AddDays(_configuration.DaysToExpiry);
            
            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            _repository.RefreshUserInfo(User1);
           // Console.WriteLine("Use -------"+User1);
            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                acessToken,
                refreshToken
            );

            
        }
        public TokenVO ValidadeCredentials(TokenVO token)
        {
            var acessToken = token.AcessToken;
            var refreshToken = token.RefrashToken;

            var principal = _tokenService.GetPrincipalFromExpiredToken(acessToken);

            var username = principal.Identity.Name;

            var user = _repository.ValidateCredentials(username);

            if (user == null || user.RefreshToken != refreshToken || user.RefreshTokenExpiryTime <= DateTime.Now)
            {
                return null;
            }

            acessToken = _tokenService.GenerateAcessToken(principal.Claims);
            refreshToken = _tokenService.GenerateRefreshToken();

            user.RefreshToken = refreshToken;

            DateTime createDate = DateTime.Now;
            DateTime expirationDate = createDate.AddMinutes(_configuration.Minutes);

            _repository.RefreshUserInfo(user);

            return new TokenVO(
                true,
                createDate.ToString(DATE_FORMAT),
                expirationDate.ToString(DATE_FORMAT),
                acessToken,
                refreshToken
            );

        }

        public bool RevokeToken(string userName)
        {
            return _repository.RevokeToken(userName);
        }
    }
}
