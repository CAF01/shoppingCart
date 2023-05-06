using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ShoppingCart.Bussiness.JWT;
using ShoppingCart.Entitys.Interfaces;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyContainerJWT
    {
        public static IServiceCollection AddJWTService(this IServiceCollection services,
                                                            IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration[JwtAuthenticationManager.JWT_KEY])),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            services.AddScoped<IAuthenticationManager, JwtAuthenticationManager>();

            return services;
        }
    }
}
