using AtleticaCore.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AtleticaCore.Util
{
    public class TokenGenerator
    {
        private readonly IConfiguration _configuration;

        public TokenGenerator(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GenerateToken(Usuario usuario)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configuration["SecurityKey"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[] 
                { 
                    new Claim(ClaimTypes.Name,usuario.NOME.ToString()),
                }),
                Expires = DateTime.UtcNow.AddMinutes(5),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
