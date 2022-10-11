using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration configuration;

        public TokenService(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public string GenerarToken(Usuario usuario)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            string secretKey = jwtSettings.GetValue<string>("SecretKey");
            int minutes = jwtSettings.GetValue<int>("MinutesToExpiration");
            string issuer = jwtSettings.GetValue<string>("Issuer");
            string audience = jwtSettings.GetValue<string>("Audience");

            var key = Encoding.ASCII.GetBytes(secretKey);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usuario.Username));
            claims.Add(new Claim(ClaimTypes.Email, usuario.Email));
            //claims.Add(new Claim(ClaimTypes.Role, usuario.Perfil.Nombre));


            var token = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: claims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddSeconds(60),
                signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}
