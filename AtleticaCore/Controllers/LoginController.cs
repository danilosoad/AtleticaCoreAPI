using AtleticaCore.Model;
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
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _repo;
        private readonly Hash _hash;
        private readonly IConfiguration _configuration;
        private readonly TokenGenerator _token;

        public LoginController(IUserRepository repo, Hash hash, IConfiguration configuration, TokenGenerator token)
        {
            _repo = repo;
            _hash = hash;
            _configuration = configuration;
            _token = token;
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
                    var token = _token.GenerateToken(result);

                    result.SENHA = "";
                    result.SALT = "";
                    return Ok(new { token = token, user = result  });
                }
                else
                {
                    return Unauthorized("Invalid Credentials..");
                }
            }
            else
            {
                return NotFound("Invalid user or password..");
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
