using ApiUsuario.DTO.Usuario;
using ApiUsuario.Services.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioInterface usuarioInterfaces;

        public LoginController(IUsuarioInterface  usuarioInterfaces)
        {
            this.usuarioInterfaces = usuarioInterfaces;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegistrarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = await usuarioInterfaces.RegistrarUsuario(usuarioCriacaoDto);  
            return Ok(usuario);
        }
    }
}
