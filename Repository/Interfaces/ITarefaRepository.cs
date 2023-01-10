using Teste.Models;

namespace Teste.Repository.Interfaces
{
    public interface ITarefaRepository
    {
        Task<List<Tarefa>> BuscarTodos();
        Task<Tarefa> BuscarPorID(int id);
        Task<Tarefa> Adicionar(Tarefa usuario);
        Task<Tarefa> Atualizar(Tarefa usuario, int id);
        Task<bool> Excluir (int id);   
    }
}
