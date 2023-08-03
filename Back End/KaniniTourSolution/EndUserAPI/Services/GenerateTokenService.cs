using EndUserAPI.Interfaces;
using EndUserAPI.Models.DTOs;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EndUserAPI.Services
{
    public class GenerateTokenService:IGenerateToken
    {
        private readonly SymmetricSecurityKey _key;

        public GenerateTokenService(IConfiguration configuration)
        {
            _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }

        public string GenerateToken(UserDTO user)
        {
            if (user.UserId != null && user.Role != null)
            {
                //User identity
                var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.NameId,user.UserId.ToString()),
                new Claim(ClaimTypes.Role,user.Role)

            };

                //Signature algorithm
                var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha256);
                //Assembling the token details
                var tokenDescription = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(3),
                    SigningCredentials = cred
                };
                //Using teh handler to generate the token
                var tokenHandler = new JwtSecurityTokenHandler();
                var myToken = tokenHandler.CreateToken(tokenDescription);
                string token = tokenHandler.WriteToken(myToken);
                return token;
            }
            return "";
        }
    }
}
