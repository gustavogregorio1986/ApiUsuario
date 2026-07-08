using Microsoft.AspNetCore.SignalR;
using System.Security.Cryptography;

namespace ApiUsuario.Services.Senha
{
    public class SenhaService : ISenhaInterface
    {


        public void CriarSenhaHash(string senha, out byte[] senhaHash, out byte[] senhaSalt)
        {
            using (var hmac = new HMACSHA3_512())
            {
                senhaHash = hmac.Key;
                senhaHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(senha));
            }
        }
    }
}
