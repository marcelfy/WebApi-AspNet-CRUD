using Teste.Models;

namespace Teste.Repository.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> BuscarTodos();
        Task<Usuario> BuscarPorID(int id);
        Task<Usuario> Adicionar(Usuario usuario);
        Task<Usuario> Atualizar(Usuario usuario, int id);
        Task<bool> Excluir (int id);   
    }
}
