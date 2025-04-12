using ApiNexus.Models;
using ApiNexus.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ApiNexus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : Controller
    {

        IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<IActionResult> fazerLogin(string email, string senha)
        {
            
            UsuarioModel usuario = await _usuarioRepository.login(email, senha);  

            if(usuario == null) return NotFound("usuario nao encontrado");
           
            return Ok(usuario);

        }
    }
}
