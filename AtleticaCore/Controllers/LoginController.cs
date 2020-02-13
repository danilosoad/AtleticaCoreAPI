using AtleticaCore.Repository;
using AtleticaCore.Util;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly IUserRepository _repo;
        private readonly Hash _hash;
        public LoginController(IUserRepository repo, Hash hash)
        {
            _repo = repo;
            _hash = hash;
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
                    return Ok();
                }
                else
                {
                    return Unauthorized();
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
