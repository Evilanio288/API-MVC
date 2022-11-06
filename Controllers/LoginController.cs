using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Anuncios.mvc.Data;
using Anuncios.mvc.Models;

namespace Anuncios.mvc.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly AnunciosmvcContext _context;

        public LoginController(AnunciosmvcContext context)
        {
            _context = context;
        }


      

        // POST: api/Login
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> PostUsuarioModel(LoginRequestModel loginModel)
        {
            var usuarioModel = await _context.Usuarios.Where(a =>a.Email ==loginModel.Email).FirstOrDefaultAsync();

            if (usuarioModel == null)
            {
                return NotFound();
            }

            if( usuarioModel.Senha != loginModel.Senha)
            {
                return BadRequest(new {error = "senha inválida !"});
            }

            return Ok(new {id = usuarioModel.Id, nome = usuarioModel.Nome });
        }


        private bool UsuarioModelExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
