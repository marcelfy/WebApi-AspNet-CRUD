using Microsoft.EntityFrameworkCore;
using Teste.Data;
using Teste.Models;
using Teste.Repository.Interfaces;

namespace Teste.Repository
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly TesteDbContext _dbContext;

        public TarefaRepository(TesteDbContext testeDbContext)
        {
            _dbContext = testeDbContext;
        }
        public async Task<Tarefa> BuscarPorID(int id)
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).FirstOrDefaultAsync(u => u.TarefaID == id);
        }

        public async Task<List<Tarefa>> BuscarTodos()
        {
            return await _dbContext.Tarefas.Include(x => x.Usuario).ToListAsync();
        }

        public async Task<Tarefa> Adicionar(Tarefa tarefa)
        {
            await _dbContext.Tarefas.AddAsync(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> Atualizar(Tarefa tarefa, int id)
        {
            Tarefa tarefaa = await BuscarPorID(id);
            if(tarefa == null)
            {
                throw new Exception("Usuário não encontrado");
            }
            tarefaa.Titulo = tarefa.Titulo;
            tarefaa.Descricao = tarefa.Descricao;
            tarefaa.Status = tarefa.Status;

            _dbContext.Tarefas.Update(tarefa);
            await _dbContext.SaveChangesAsync();
            return tarefaa;
        }

        public async Task<bool>Excluir(int id)
        {
            Tarefa tarefa = await BuscarPorID(id);
            if (tarefa == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            _dbContext.Tarefas.Remove(tarefa);
            await _dbContext.SaveChangesAsync();
            return true;
        }
    }
}
