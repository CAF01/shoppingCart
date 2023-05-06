using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Entitys.Exceptions;
using ShoppingCart.Entitys.Interfaces;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.Bussiness.JWT
{
    public class JwtAuthenticationManager
         : IAuthenticationManager
    {
        public const string JWT_KEY = "JWT";

        private readonly IConfiguration configuration;

        public JwtAuthenticationManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GetTokenAsync(string user)
        {

            string PrivateKey = configuration[JWT_KEY];

            if (string.IsNullOrEmpty(PrivateKey))
            {
                throw new GeneralException("Private key JWT not found.");
            }

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();

            var tokenKey = Encoding.ASCII.GetBytes(PrivateKey);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
