using ApiUsuario.DTO.Usuario;
using ApiUsuario.Models;
using ApiUsuario.Services.Usuario;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace ApiUsuario.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioInterface _usuarioInterface;

        public UsuarioController(IUsuarioInterface usuarioInterface)
        {
            this._usuarioInterface = usuarioInterface;
        }

        [HttpGet]
        public async Task<IActionResult> ListarUsuarios()
        {
            var usuarios = await _usuarioInterface.ListarUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarUsuarioPorId(int id)
        {
            var usuario = await _usuarioInterface.BuscarUsuarioPorId(id);
            return Ok(usuario);
        }

        [HttpPut]
        public async Task<IActionResult> EditarUsuario(UsuarioEdicaoDto usuarioEdicaoDto)
        {
            var usuario = await _usuarioInterface.EditarUsuario(usuarioEdicaoDto);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> RemoverUsuario(int id)
        {
            var usuario = await _usuarioInterface.RemoverUsuario(id);
            return Ok(usuario);
        }
    }
}
