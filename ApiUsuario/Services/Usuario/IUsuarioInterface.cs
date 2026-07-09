using ApiUsuario.DTO.Usuario;
using ApiUsuario.Models;

namespace ApiUsuario.Services.Usuario
{
    public interface IUsuarioInterface
    {
        //retorno nome metodo
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDto usuarioCriacaoDto);

        Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios();
        Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int id);
    }
}
