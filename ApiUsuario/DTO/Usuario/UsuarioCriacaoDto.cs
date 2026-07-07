using System.ComponentModel.DataAnnotations;

namespace ApiUsuario.DTO.Usuario
{
    public class UsuarioCriacaoDto
    {
        [Required(ErrorMessage = "Digite o usuário")]
        public string Usuario { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite o nome")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "Digite o sobrenome")]
        public string Sobrenome { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataAlteracao { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "Digite o senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Digite o confirma senha"),
            Compare("Senha", ErrorMessage = "As senhas não coincidem")] 
        public string ConfrimaSenha { get; set; }
    }
}
