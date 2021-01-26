using System;
using System.Collections.Generic;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Text;
using Projeto.Apresentacao.Repositories;

namespace Projeto.Apresentacao.Configurations
{
    public class TokenService
    {
        //private readonly AppSettings appSettings;

        public string GenerateToken(UserEntity user)
        {

        var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(AppSettings.Secret);

            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity
                    (new Claim[] { new Claim(ClaimTypes.Name, user.Username.ToString()) }),
                Expires = DateTime.Now.AddDays(12),

                SigningCredentials = new SigningCredentials
                    (new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }
    }
}
