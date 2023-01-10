using Teste.Enums;

namespace Teste.Models
{
    public class Tarefa
    {
        public int TarefaID { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public StatusTarefa Status { get; set; }
        public int? UsuarioID { get; set; }
        
        public virtual Usuario? Usuario { get; set; }
    }
}
