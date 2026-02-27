using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
namespace Zoo_API.Services
{
    public class JwtServices
    {
        private readonly IConfiguration _config;
        public JwtServices(IConfiguration config)
        {
            _config = config;
        }

        //Generating Token
        public string GenerateToken(string username)
        {
            //create a key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            //signing credentials
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //Create claims
            var claims = new[]
            {
                new Claim(ClaimTypes.Name , username),
                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
            };

            //Create Tokens
            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: creds

                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
