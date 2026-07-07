using ApiUsuario.DTO.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost("register")]
        public IActionResult RegistrarUsuario(UsuarioCriacaoDto usuario)
        {
            return Ok();
        }
    }
}
