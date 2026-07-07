using ApiUsuario.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiUsuario.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<UsuarioModel> Usuarios { get; set; }
    }
}
