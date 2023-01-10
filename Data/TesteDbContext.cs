using Microsoft.EntityFrameworkCore;
using Teste.Data.Map;
using Teste.Models;

namespace Teste.Data
{
    public class TesteDbContext: DbContext
    {
        public TesteDbContext(DbContextOptions<TesteDbContext> options): base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Tarefa> Tarefas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UsuarioMap());
            modelBuilder.ApplyConfiguration(new TarefaMap());
            base.OnModelCreating(modelBuilder); 
        }
    }
}
