using Chapter.Interfaces;
using Chapter.Models;
using Chapter.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using System.Linq.Expressions;

namespace Chapter.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _iUsuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _iUsuarioRepository = usuarioRepository;
        }

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                return Ok(_iUsuarioRepository.Listar());
            }
            catch (Exception)
            {
                throw;
            }

        }


        [HttpGet("{id}")]

        public IActionResult BuscarPorId(int id)
        {

            try
            {
                Usuario usuarioEncontrado = _iUsuarioRepository.BuscarPorId(id);

                if (usuarioEncontrado == null)
                {
                    return NotFound();
                }
                return Ok(usuarioEncontrado);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPost("{id}")]

        public IActionResult Alterar(int id, Usuario usuario) 
        {
         try
            {
                _iUsuarioRepository.Atualizar(id, usuario);
                return Ok("Usuario alterado");    
            }
               catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("{id}")]

        public IActionResult Deletar(int id) 
        {
         try
            {
                _iUsuarioRepository.Deletar(id);
                return Ok("Usuario Deletado");
            }
            catch (Exception)
            {
                throw;
            }

        }
    }    
    

}
