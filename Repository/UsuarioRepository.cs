using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Models;
using Teste.Repository.Interfaces;

namespace Teste.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TesteDbContext _dbContext;

        public UsuarioRepository(TesteDbContext testeDbContext)
        {
            _dbContext = testeDbContext;
        }
        public async Task<Usuario> BuscarPorID(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(u => u.UsuarioID == id);
        }

        public async Task<List<Usuario>> BuscarTodos()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<Usuario>Adicionar(Usuario usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();
            return usuario;
        }

        public async Task<Usuario> Atualizar(Usuario usuario, int id)
        {
            Usuario user = await BuscarPorID(id);
            if(user == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            user.Nome = usuario.Nome;
            user.Email = usuario.Email;
            user.Sexo = usuario.Sexo;

            _dbContext.Usuarios.Update(user);
            await _dbContext.SaveChangesAsync();
            return user;
        }

        public async Task<bool>Excluir(int id)
        {
            Usuario user = await BuscarPorID(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _dbContext.Usuarios.Remove(user);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
