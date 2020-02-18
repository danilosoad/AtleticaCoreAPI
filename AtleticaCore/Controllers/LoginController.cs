using AtleticaCore.Repository;
using AtleticaCore.Util;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace AtleticaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserRepository _repo;
        private readonly Hash _hash;
        private readonly IConfiguration _configuration;

        public LoginController(IUserRepository repo, Hash hash, IConfiguration configuration)
        {
            _repo = repo;
            _hash = hash;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]LoginModel model)
        {
            var result = await _repo.GetUserByLogin(model.typedLogin);

            if(result != null)
            {
                var storedPassword = result.SENHA;
                
                var authenticated =  _hash.ValidatePassword(model.typedPassword,result.SALT,storedPassword);
                
                if (authenticated)
                {
                    //cria-se token aqui
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.Name, result.NOME),
                        new Claim(ClaimTypes.NameIdentifier, result.ID.ToString())
                    };

                    //recebe uma instancia da classe symmetric security key
                    //armazenando a chave de criptografia usada na criação do token
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

                    //recebe um objeto Sigin Credentials contendo a chave de criptografia e o algoritmo de segurança
                    var creds = new SigningCredentials(key,SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: "AtleticaCoreApi",
                        audience: "AtleticaCoreSPA",
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
                }
                else
                {
                    return Unauthorized("Invalid Credentials..");
                }
            }
            else
            {
                return NotFound();
            }
        }
    }

    #region POCO CLASS
    public class LoginModel
    {
        public string typedPassword { get; set; }
        public string typedLogin { get; set; }
    }
    #endregion
}
