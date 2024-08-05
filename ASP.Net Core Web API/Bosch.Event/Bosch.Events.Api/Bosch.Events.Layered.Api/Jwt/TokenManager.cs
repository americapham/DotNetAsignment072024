using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Bosch.Events.Domain.Entities;
using Microsoft.IdentityModel.Tokens;

namespace Bosch.Events.Layered.Api.Jwt
{
    public class TokenManager : ITokenManager
    {
        private readonly SymmetricSecurityKey _key;
        public TokenManager(IConfiguration config)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["BoschJwtSecret:Key"]));
        }
        public string GenerateToken(User user, string roleName)
        {
            var claims = new List<Claim>{
           new Claim(ClaimTypes.Email,user.UserName),
           new Claim(ClaimTypes.Role,roleName),
       };
            var credentials = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddMinutes(60),
                SigningCredentials = credentials,
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
