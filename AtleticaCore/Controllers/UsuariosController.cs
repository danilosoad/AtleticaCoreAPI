using AtleticaCore.Model;
using AtleticaCore.Repository;
using AtleticaCore.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AtleticaCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuariosController : Controller
    {
        private readonly Hash _hash;

        public IUserRepository _repo { get; }
        public UsuariosController(IUserRepository repo, Hash hash)
        {
            _repo = repo;
            _hash = hash;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllUsersAsync();
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var result = await _repo.GetUserByIdAsync(id);
                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post(Usuario model)
        {
            try
            {
                if (string.IsNullOrEmpty(model.SENHA))
                    return BadRequest();

                var salt = _hash.SaltCreate();
                model.SENHA = _hash.CryptByCore(model.SENHA,salt);
                model.SALT = salt;

                _repo.Add(model);

                if (await _repo.SaveChangesAsync())
                {
                    return Created($"api/usuario/{model.ID}",model);
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var usuario = await _repo.GetUserByIdAsync(id);

                if (usuario == null)
                    return NotFound();
                
                    _repo.Delete(usuario);

                if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
            return BadRequest();
        }
    }
}
