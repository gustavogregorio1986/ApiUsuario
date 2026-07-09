using ApiUsuario.Data;
using ApiUsuario.DTO.Usuario;
using ApiUsuario.Models;
using ApiUsuario.Services.Senha;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuario.Services.Usuario
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly ApplicationDbContext _context;
        private readonly ISenhaInterface _senhaInterface;

        public UsuarioService(ApplicationDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<UsuarioModel>> BuscarUsuarioPorId(int id)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();
            try
            {
                var usuario = await _context.Usuarios.FindAsync(id);
                if(usuario == null)
                {
                    response.Mensagem = "Usuário não encontrado.";
                    response.Status = false;
                    return response;
                }
                response.Dados = usuario;
                response.Mensagem = "Usuário localizado.";
                return response;
            }
            catch(Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<UsuarioModel>>> ListarUsuarios()
        {
            ResponseModel<List<UsuarioModel>> response = new ResponseModel<List<UsuarioModel>>();
            try
            {
                var usuarios = await _context.Usuarios.ToListAsync();
                response.Dados = usuarios;
                response.Mensagem = "usuario localizado"; 
                return response;
            }
            catch (Exception ex) 
            { 
               response.Mensagem = ex.Message;
               response.Status = false;
                return response;    
            }

        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (VerificaSeExisteEmailUsuario(usuarioCriacaoDto))
                {
                    response.Mensagem = "Usuário/e-mail já cadastrado.";
                    response.Status = false;
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioCriacaoDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);


                UsuarioModel usuario = new UsuarioModel()
                {
                    Usuario = usuarioCriacaoDto.Usuario,
                    Email = usuarioCriacaoDto.Email,
                    Nome = usuarioCriacaoDto.Nome,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuário cadastrado com sucesso.";
                response.Dados = usuario;
                return response;
            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        private bool VerificaSeExisteEmailUsuario(UsuarioCriacaoDto usuarioCriacaoDto)
        {
            var usuario = _context.Usuarios
                .FirstOrDefault(item => item.Email == usuarioCriacaoDto.Email
                                     || item.Usuario == usuarioCriacaoDto.Usuario);

            if (usuario != null)
            {
                return true; // já existe
            }

            return false; // não existe
        }
    }
}
